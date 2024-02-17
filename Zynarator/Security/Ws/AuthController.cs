using System.Security.Claims;
using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Common;
using DotnetGenerator.Zynarator.Security.Jwt;
using DotnetGenerator.Zynarator.Security.Payload.Request;
using DotnetGenerator.Zynarator.Security.Payload.Response;
using JasperFx.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DotnetGenerator.Zynarator.Security.Ws.Facade;

[Route("/")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;

    public AuthController(UserManager<User> userManager, RoleManager<Role> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
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
            SecurityStamp = Guid.NewGuid().ToString(),
        };

        var createResult = await _userManager.CreateAsync(user, signupRequest.Password);

        if (!createResult.Succeeded)
        {
            var err = createResult.Errors.Aggregate("Failed to create user: ",
                (current, error) => current + $"# {error}");
            return BadRequest(err);
        }

        // add the roles
        if (signupRequest.Roles.Count == 0) signupRequest.Roles.Add(AuthoritiesConstants.User);
        foreach (var userRole in signupRequest.Roles)
        {
            await _userManager.AddToRoleAsync(user, userRole);
        }

        return Ok("new user created!");
    }

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult> Login([FromBody] LoginRequest login)
    {
        var user = await _userManager.FindByNameAsync(login.Username);
        if (user is null) return Unauthorized("Invalid Credentials!");

        var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, login.Password);
        if (!isPasswordCorrect) return Unauthorized("Invalid Credentials!");

        user.Roles = (await _userManager.GetRolesAsync(user)).Map(e => new Role(e)).ToHashSet();

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.UserName!),
            new("id", user.Id.ToString()),
            new("JWTID", Guid.NewGuid().ToString()),
        };
        claims.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role, role.Name!)));

        var token = JwtUtils.GenerateToken(claims);

        return Ok(new JwtResponse
            {
                Id = user.Id.ToString(),
                Email = user.Email,
                Roles = user.Roles.Select(role => role.Name!).ToHashSet(),
                Token = token,
                Username = user.UserName,
            }
        );
    }
}