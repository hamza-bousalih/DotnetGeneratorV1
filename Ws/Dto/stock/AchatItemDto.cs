using DotnetGenerator.Zynarator.Dto;

namespace DotnetGenerator.Ws.Dto;

public class AchatItemDto : BaseDto
{
    public decimal PrixUnitaire { get; set; }
    public decimal PrixVente { get; set; }
    public decimal Quantite { get; set; }
    public decimal QuantiteAvoir { get; set; }
    public decimal Remise { get; set; }

    public ProduitDto? Produit { get; set; }
    public AchatDto? Achat { get; set; }
}