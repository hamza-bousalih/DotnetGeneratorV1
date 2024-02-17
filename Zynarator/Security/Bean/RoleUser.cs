
using DotnetGenerator.Zynarator.Audit;

namespace DotnetGenerator.Zynarator.Security.Bean;

public class RoleUser : AuditBusinessObject
{
    public User? User { get; set; }
    public Role? Role { get; set; }
}