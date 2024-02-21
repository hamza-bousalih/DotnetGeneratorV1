using System.ComponentModel.DataAnnotations.Schema;
using DotnetGenerator.Zynarator.Bean;
using Microsoft.AspNetCore.Identity;

namespace DotnetGenerator.Zynarator.Security.Bean;

public class Role : IdentityRole<long>, IBusinessObject
{
    public string? Authority
    {
        get => Name;
        set => Name = value;
    }

    [InverseProperty(nameof(RoleUser.Role))]
    public List<RoleUser>? RoleUsers { get; set; }
    
    public Role()
    {
    }

    public Role(string authority) : base(authority)
    {
    }
}