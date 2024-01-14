using DotnetGenerator.Zynarator.Audit;

namespace DotnetGenerator.Bean.Core;

public class AchatItem: AuditBusinessObject
{
    public new int Id
    {
        get => base.Id;
        set => base.Id = value;
    }
    public decimal PrixUnitaire { get; set; }
    public decimal PrixVente { get; set; }
    public decimal Quantite { get; set; }
    public decimal QuantiteAvoir { get; set; }
    public decimal Remise { get; set; }

    public Produit Produit { get; set; }
    public Achat Achat { get; set; }
}