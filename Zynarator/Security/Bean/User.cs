using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper.Configuration.Annotations;
using DotnetGenerator.Zynarator.Bean;
using Microsoft.AspNetCore.Identity;

namespace DotnetGenerator.Zynarator.Security.Bean;

public class User : IdentityUser<long>, IBusinessObject
{
    public bool? Enabled { get; set; } = true;
    public bool? AccountNonExpired { get; set; } = true;
    public bool? CredentialsNonExpired { get; set; } = true;
    public bool? AccountNonLocked { get; set; } = true;
    public bool? PasswordChanged { get; set; } = true;
    public override string? Email { get; set; }
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    
    [NotMapped]
    public string Password { get; set; }
    public DateTime createdAt;

    [NotMapped]
    public string? Phone
    {
        get => PhoneNumber;
        set => PhoneNumber = value;
    }

    public List<RoleUser>? RoleUsers { get; set; }
    public List<ModelPermissionUser>? ModelPermissionUsers { get; set; }

    public User()
    {
    }

    public User(string userName) : base(userName)
    {
    }
}