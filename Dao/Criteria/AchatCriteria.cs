using DotnetGenerator.Zynarator.Criteria;

namespace DotnetGenerator.Dao.Criteria;

public class AchatCriteria: BaseCriteria
{
    public string? Reference;
    public string? ReferenceLike;
    public DateTime? DateAchat;
    public DateTime? DateAchatFrom;
    public DateTime? DateAchatTo;
    public string? Total;
    public string? TotalMin;
    public string? TotalMax;
    public string? TotalPaye;
    public string? TotalPayeMin;
    public string? TotalPayeMax;
    public string? Description;
    public string? DescriptionLike;

    public ClientCriteria? Client;
    public List<ClientCriteria>? Clients;
}