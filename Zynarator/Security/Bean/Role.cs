using DotnetGenerator.Zynarator.Audit;

namespace DotnetGenerator.Zynarator.Security.Bean;

public class Role : AuditBusinessObject
{
    public string? Authority { get; set; }

    public Role(string? authority)
    {
        Authority = authority;
    }
}