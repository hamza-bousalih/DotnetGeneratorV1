using DotnetGenerator.Zynarator.Criteria;

namespace DotnetGenerator.Zynarator.Security.Dao.Criteria;

public class ModelPermissionCriteria : BaseCriteria
{
    public string? Reference { get; set; }
    public string? ReferenceLike { get; set; }
    public string? Libelle { get; set; }
    public string? LibelleLike { get; set; }
}