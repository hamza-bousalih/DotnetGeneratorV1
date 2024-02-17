using DotnetGenerator.Zynarator.Criteria;

namespace DotnetGenerator.Zynarator.Security.Dao.Criteria;

public class RoleCriteria : BaseCriteria
{
    public string? Authority { get; set; }
    public string? AuthorityLike { get; set; }
}