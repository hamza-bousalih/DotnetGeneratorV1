using DotnetGenerator.Zynarator.Criteria;

namespace DotnetGenerator.Dao.Criteria;

public class ClientCriteria: BaseCriteria
{
    public string? Cin { get; set; }
    public string? CinLike { get; set; }
    public string? Nom { get; set; }
    public string? NomLike { get; set; }
    public string? Tel { get; set; }
    public string? TelLike { get; set; }
    public string? Email { get; set; }
    public string? EmailLike { get; set; }
    public string? Adresse { get; set; }
    public string? AdresseLike { get; set; }
    public string? Description { get; set; }
    public string? DescriptionLike { get; set; }
    public string? Creance { get; set; }
    public string? CreanceMin { get; set; }
    public string? CreanceMax { get; set; }

}
