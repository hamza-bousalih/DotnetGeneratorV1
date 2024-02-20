using DotnetGenerator.Zynarator.Criteria;

namespace DotnetGenerator.Dao.Criteria;

public class AchatItemCriteria : BaseCriteria
{
    public string? PrixUnitaire { get; set; }
    public string? PrixUnitaireMin { get; set; }
    public string? PrixUnitaireMax { get; set; }
    public string? PrixVente { get; set; }
    public string? PrixVenteMin { get; set; }
    public string? PrixVenteMax { get; set; }
    public string? Quantite { get; set; }
    public string? QuantiteMin { get; set; }
    public string? QuantiteMax { get; set; }
    public string? QuantiteAvoir { get; set; }
    public string? QuantiteAvoirMin { get; set; }
    public string? QuantiteAvoirMax { get; set; }
    public string? Remise { get; set; }
    public string? RemiseMin { get; set; }
    public string? RemiseMax { get; set; }

    public ProduitCriteria? Produit { get; set; }
    public List<ProduitCriteria>? Produits { get; set; }
    public AchatCriteria? Achat { get; set; }
    public List<AchatCriteria>? Achats { get; set; }
}