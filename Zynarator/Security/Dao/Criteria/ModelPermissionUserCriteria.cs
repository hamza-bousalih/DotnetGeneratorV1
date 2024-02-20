using DotnetGenerator.Zynarator.Criteria;

namespace DotnetGenerator.Zynarator.Security.Dao.Criteria;

public class ModelPermissionUserCriteria : BaseCriteria
{
    public bool? Value { get; set; }
    public string? SubAttribute { get; set; }
    public string? SubAttributeLike { get; set; }

    public ActionPermissionCriteria? ActionPermission { get; set; }
    public List<ActionPermissionCriteria>? ActionPermissions { get; set; }
    public ModelPermissionCriteria? ModelPermission { get; set; }
    public List<ModelPermissionCriteria>? ModelPermissions { get; set; }
    public UserCriteria? User { get; set; }
    public List<UserCriteria>? Users { get; set; }
}