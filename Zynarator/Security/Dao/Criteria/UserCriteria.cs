using DotnetGenerator.Zynarator.Criteria;

namespace DotnetGenerator.Zynarator.Security.Dao.Criteria;

public class UserCriteria : BaseCriteria
{
    public bool? CredentialsNonExpired { get; set; }
    public bool? Enabled { get; set; }
    public string? Email { get; set; }
    public string? EmailLike { get; set; }
    public bool? AccountNonExpired { get; set; }
    public bool? AccountNonLocked { get; set; }
    public string? Username { get; set; }
    public string? UsernameLike { get; set; }
    public string? Password { get; set; }
    public string? PasswordLike { get; set; }
    public bool? PasswordChanged { get; set; }
    public string? LastName { get; set; }
    public string? LastNameLike { get; set; }
    public string? FirstName { get; set; }
    public string? FirstNameLike { get; set; }
    public string? Phone { get; set; }
    public string? PhoneLike { get; set; }
}