using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Dao.Criteria;
using DotnetGenerator.Zynarator.Specification;

namespace DotnetGenerator.Zynarator.Security.Dao.Specification;

public class RoleSpecification : AbstractSpecification<Role, RoleCriteria>
{
    public RoleSpecification(AppDbContext context) : base(context.Roles)
    {
    }

    protected override void ConstructPredicates()
    {
        AddPredicateId();

        AddPredicate(e => e.Authority.EqualsString(Criteria.Authority));
        AddPredicate(e => e.Authority.ContainsString(Criteria.AuthorityLike));
    }
}