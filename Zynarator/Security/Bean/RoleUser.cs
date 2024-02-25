using System.ComponentModel.DataAnnotations.Schema;
using DotnetGenerator.Zynarator.Bean;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerator.Zynarator.Security.Bean;

[PrimaryKey("Id")]
public class RoleUser : IdentityUserRole<long>, IBusinessObject
{
    [ForeignKey(nameof(User))]
    public override long UserId { get; set; }
    
    [ForeignKey(nameof(Role))]
    public override long RoleId { get; set; }
    
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