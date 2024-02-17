using DotnetGenerator.Zynarator.Audit;

namespace DotnetGenerator.Zynarator.Security.Bean;

public class ModelPermission : AuditBusinessObject
{
    public string? Reference { get; set; }
    public string? Libelle { get; set; }
}