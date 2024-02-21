using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Dao.Criteria;
using DotnetGenerator.Zynarator.Specification;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerator.Zynarator.Security.Dao.Specification;

public class RoleUserSpecification : SpecificationHelper<RoleUser, RoleUserCriteria>
{
    public RoleUserSpecification(AppDbContext context) : base(context.RoleUsers)
    {
    }

    protected override IQueryable<RoleUser> SetIncluded()
    {
        return Query
            .Include(ru => ru.Role)
            .Include(ru => ru.User);
    }

    public override void DefinePredicates()
    {
        Predicates = new List<Func<RoleUser, bool>>();
        ConstructPredicates();
    }

    protected void ConstructPredicates()
    {
        AddPredicateId();

        AddPredicateIf(Criteria.User is not null, e => e.User!.Id == Criteria.User!.Id);
        AddPredicateIf(Criteria.Users is not null, e => e.User!.Id.In(Criteria.Users!.Ids()));
        AddPredicateIf(Criteria.User is not null, e => e.User!.UserName == Criteria.User!.Username);
        AddPredicateIf(Criteria.Role is not null, e => e.Role!.Id == Criteria.Role!.Id);
        AddPredicateIf(Criteria.Roles is not null, e => e.Role!.Id.In(Criteria.Roles!.Ids()));
        AddPredicateIf(Criteria.Role is not null, e => e.Role!.Authority == Criteria.Role!.Authority);
    }
}