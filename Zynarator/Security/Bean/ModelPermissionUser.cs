using DotnetGenerator.Zynarator.Audit;

namespace DotnetGenerator.Zynarator.Security.Bean;

public class ModelPermissionUser : AuditBusinessObject
{
    public bool? Value { get; set; }
    public string? SubAttribute { get; set; }

    public ActionPermission? ActionPermission { get; set; }
    public ModelPermission? ModelPermission { get; set; }
    public User? User { get; set; }
}