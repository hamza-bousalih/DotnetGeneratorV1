using System.ComponentModel.DataAnnotations.Schema;
using DotnetGenerator.Zynarator.Bean;
using Microsoft.AspNetCore.Identity;

namespace DotnetGenerator.Zynarator.Security.Bean;

public class RoleUser : IdentityUserRole<long>, IBusinessObject
{
    public long Id { get; set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    [ForeignKey(nameof(RoleId))]
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