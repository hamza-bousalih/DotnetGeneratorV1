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

[Route("/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserService _userService;

    public AuthController(IContainer container)
    {
        _userService = container.GetInstance<UserService>();
    }

    [HttpPost]
    [Route("signup")]
    public async Task<ActionResult> Signup([FromBody] SignupRequest signupRequest)
    {
        var usernameToken = await _userService.FindByUsername(signupRequest.Username) != null;
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
            user.RoleUsers.Add(new RoleUser {Role = new Role(Roles.User)});

        await _userService.Create(user);
        
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