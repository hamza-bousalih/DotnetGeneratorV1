using DotnetGenerator.Zynarator.Criteria;

namespace DotnetGenerator.Zynarator.Security.Dao.Criteria;

public class RoleUserCriteria : BaseCriteria
{
    public UserCriteria? User { get; set; }
    public List<UserCriteria>? Users { get; set; }
    public RoleCriteria? Role { get; set; }
    public List<RoleCriteria>? Roles { get; set; }
}