using DotnetGenerator.Zynarator.Bean;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerator.Zynarator.Security.Bean;

[PrimaryKey("Id")]
public class RoleUser : IdentityUserRole<long>, IBusinessObject
{
    public long Id { get; set; }

    public User? User { get; set; }
    public Role? Role { get; set; }

    public RoleUser()
    {
    }

    public RoleUser(User? user, Role? role)
    {
        User = user;
        Role = role;
    }
}