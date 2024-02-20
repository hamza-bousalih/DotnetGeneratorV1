using DotnetGenerator.Zynarator.Criteria;

namespace DotnetGenerator.Dao.Criteria;

public class AchatCriteria : BaseCriteria
{
    public string? Reference { get; set; }
    public string? ReferenceLike { get; set; }
    public DateTime? DateAchat { get; set; }
    public DateTime? DateAchatFrom { get; set; }
    public DateTime? DateAchatTo { get; set; }
    public string? Total { get; set; }
    public string? TotalMin { get; set; }
    public string? TotalMax { get; set; }
    public string? TotalPaye { get; set; }
    public string? TotalPayeMin { get; set; }
    public string? TotalPayeMax { get; set; }
    public string? Description { get; set; }
    public string? DescriptionLike { get; set; }

    public ClientCriteria? Client { get; set; }
    public List<ClientCriteria>? Clients { get; set; }
}