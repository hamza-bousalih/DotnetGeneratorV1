using DotnetGenerator.Zynarator.Audit;

namespace DotnetGenerator.Bean.Core;

public class Client: AuditBusinessObject
{
    public string? Cin { get; set; }
    public string? Nom { get; set; }
    public string? Email { get; set; }
    public string? Description { get; set; }
    public decimal? Creance { get; set; }

    public List<Achat>? Achats { get; set; }
}