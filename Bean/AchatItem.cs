namespace DotnetGenerator.Bean;

public class AchatItem
{
    public int Id { get; set; }
    public decimal PrixUnitaire { get; set; }
    public decimal PrixVente { get; set; }
    public decimal Quantite { get; set; }
    public decimal QuantiteAvoir { get; set; }
    public decimal Remise { get; set; }

    public int ProduitId { get; set; }
    public Produit Produit { get; set; }
    public int AchatId { get; set; }
    public Achat Achat { get; set; }
}