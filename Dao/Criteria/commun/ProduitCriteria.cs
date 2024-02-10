using DotnetGenerator.Zynarator.Criteria;

namespace DotnetGenerator.Dao.Criteria;

public class ProduitCriteria: BaseCriteria
{
    public string? Reference { get; set; }
    public string? ReferenceLike { get; set; }
    public string? Libelle { get; set; }
    public string? LibelleLike { get; set; }
    public string? Barcode { get; set; }
    public string? BarcodeLike { get; set; }
    public string? Discription { get; set; }
    public string? DiscriptionLike { get; set; }
    public string? PrixAchatMoyen { get; set; }
    public string? PrixAchatMoyenMin { get; set; }
    public string? PrixAchatMoyenMax { get; set; }
    public string? Quantite { get; set; }
    public string? QuantiteMin { get; set; }
    public string? QuantiteMax { get; set; }
    public string? SeuilAlert { get; set; }
    public string? SeuilAlertMin { get; set; }
    public string? SeuilAlertMax { get; set; }

}
