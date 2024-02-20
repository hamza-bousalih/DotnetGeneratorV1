using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Dao.Criteria;
using DotnetGenerator.Zynarator.Specification;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerator.Zynarator.Security.Dao.Specification;

public class RoleSpecification : SpecificationHelper<Role, RoleCriteria>
{
    public RoleSpecification(RoleManager<Role> roleManager): base(roleManager.Roles)
    {
    }

    public override void DefinePredicates()
    {
        Predicates = new List<Func<Role, bool>>();
        ConstructPredicates();
    }

    protected void ConstructPredicates()
    {
        AddPredicateId();

        AddPredicate(e => e.Authority.EqualsString(Criteria.Authority));
        AddPredicate(e => e.Authority.ContainsString(Criteria.AuthorityLike));
    }
}