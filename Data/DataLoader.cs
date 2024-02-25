using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Common;
using DotnetGenerator.Zynarator.Security.Service.Facade;
using Lamar;

namespace DotnetGenerator.Data;

public class DataLoader
{
    private readonly RoleService _roleService;
    private readonly UserService _userService;

    public DataLoader(IContainer container)
    {
        _roleService = container.GetInstance<RoleService>();
        _userService = container.GetInstance<UserService>();
    }

    public async Task Load()
    {
        var roles = new List<Role>
        {
            new(AuthoritiesConstants.Admin),
            new(AuthoritiesConstants.User)
        };

        await _roleService.Create(roles);
        
        await _userService.Create(new User
        {
            UserName = "admin",
            Email = "admin@mail.com",
            LastName = "Admin",
            FirstName = "Admin",
            Password = "123",
            RoleUsers = roles.Select(r => new RoleUser { Role = r }).ToList()
        });
        
        await _userService.Create(new User
        {
            UserName = "user",
            Email = "user@mail.com",
            LastName = "User",
            FirstName = "User",
            Password = "123",
            RoleUsers = new List<RoleUser> { new() { Role = new Role(AuthoritiesConstants.User) } }
        });

        Console.WriteLine("Users Created");
    }
}