using DotnetGenerator.Zynarator.Audit;

namespace DotnetGenerator.Zynarator.Security.Bean;

public class User : AuditBusinessObject
{
    public bool? CredentialsNonExpired { get; set; }
    public bool? Enabled { get; set; }
    public string? Email { get; set; }
    public bool? AccountNonExpired { get; set; }
    public bool? AccountNonLocked { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public bool? PasswordChanged { get; set; }
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    public string? Phone { get; set; }

    public List<RoleUser>? RoleUsers { get; set; }
    public List<ModelPermissionUser>? ModelPermissionUsers { get; set; }
}