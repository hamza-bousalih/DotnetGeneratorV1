using DotnetGenerator.Zynarator.Audit;

namespace DotnetGenerator.Bean.Core;

public class Produit: AuditBusinessObject
{
    public new int Id
    {
        get => base.Id;
        set => base.Id = value;
    }
    public string Reference { get; set; }
    public string Libelle { get; set; }
    public string Barcode { get; set; }
    public string Discription { get; set; }
    public decimal PrixAchatMoyen { get; set; }
    public decimal Quantite { get; set; }
    public decimal SeuilAlert { get; set; }
    
    public List<AchatItem> AchatItems { get; set; }
}