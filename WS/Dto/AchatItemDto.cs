using DotnetGenerator.Zynarator.Dto;

namespace DotnetGenerator.WS.Dto;

public class AchatItemDto: BaseDto
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

    public ProduitDto Produit { get; set; }
    public AchatDto Achat { get; set; }
}