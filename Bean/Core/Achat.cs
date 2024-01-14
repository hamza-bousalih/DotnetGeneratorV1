using DotnetGenerator.Zynarator.Audit;

namespace DotnetGenerator.Bean.Core;

public class Achat: AuditBusinessObject
{
    public new int Id
    {
        get => base.Id;
        set => base.Id = value;
    }
    
    public string Reference { get; set; }
    public DateTime DateAchat { get; set; }
    public decimal Total { get; set; }
    public decimal TotalPaye { get; set; }
    public string Description { get; set; }

    public Client Client { get; set; }
    
    public List<AchatItem> AchatItems { get; set; }
}