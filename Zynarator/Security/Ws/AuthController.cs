using System.Security.Claims;
using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Common;
using DotnetGenerator.Zynarator.Security.Jwt;
using DotnetGenerator.Zynarator.Security.Payload.Request;
using DotnetGenerator.Zynarator.Security.Payload.Response;
using DotnetGenerator.Zynarator.Security.Service.Facade;
using Lamar;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DotnetGenerator.Zynarator.Security.Ws;

[Route("/")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;
    private readonly UserService _userService;

    public AuthController(UserManager<User> userManager, RoleManager<Role> roleManager, IContainer container)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _userService = container.GetInstance<UserService>();
    }

    [HttpPost]
    [Route("seed-roles")]
    public async Task<ActionResult> SeedRoles()
    {
        var roles = new List<string> { AuthoritiesConstants.User, AuthoritiesConstants.Admin };
        foreach (var role in roles)
        {
            var roleExists = await _roleManager.RoleExistsAsync(role);
            if (!roleExists) await _roleManager.CreateAsync(new Role(role));
        }

        return Ok();
    }

    [HttpPost]
    [Route("signup")]
    public async Task<ActionResult> Signup([FromBody] SignupRequest signupRequest)
    {
        var usernameToken = await _userManager.FindByNameAsync(signupRequest.Username) != null;
        if (usernameToken) return BadRequest("Username already token!");
        var user = new User
        {
            UserName = signupRequest.Username,
            Email = signupRequest.Email,
            RoleUsers = signupRequest.Roles.Select(r => new RoleUser() {Role = new Role(r)}).ToList(),
            SecurityStamp = Guid.NewGuid().ToString(),
            Password = signupRequest.Password
        };
        
        if (user.RoleUsers.Count == 0) 
            user.RoleUsers.Add(new RoleUser {Role = new Role(AuthoritiesConstants.User)});

        await _userService.Create(user);

        foreach (var userRole in user.RoleUsers) 
            await _userManager.AddToRoleAsync(user, userRole.Role!.Name!);

        return Ok("new user created!");
    }

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult> Login([FromBody] LoginRequest login)
    {
        var user = await _userService.FindByUsername(login.Username);
        if (user is null) return Unauthorized("Invalid Credentials!");

        var isPasswordCorrect = await _userService.CheckPassword(user, login.Password);
        if (!isPasswordCorrect) return Unauthorized("Invalid Credentials!");

        // user.RoleUsers = (await _userManager.GetRolesAsync(user)).Map(e => new RoleUser(user, new Role(e))).ToList();

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.UserName!),
            new("id", user.Id.ToString()),
            new("JWTID", Guid.NewGuid().ToString()),
        };

        claims.AddRange(user.RoleUsers is null
            ? new List<Claim>()
            : user.RoleUsers.Select(roleUser => new Claim("roles", roleUser.Role?.Name!)));

        var token = JwtUtils.GenerateToken(claims);

        return Ok(new JwtResponse
            {
                Id = user.Id.ToString(),
                Email = user.Email,
                Roles = user.RoleUsers?.Select(roleUser => roleUser.Role?.Name!).ToHashSet(),
                Token = token,
                Username = user.UserName,
            }
        );
    }
}