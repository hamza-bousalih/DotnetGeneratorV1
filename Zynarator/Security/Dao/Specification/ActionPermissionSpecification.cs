using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Dao.Criteria;
using DotnetGenerator.Zynarator.Specification;

namespace DotnetGenerator.Zynarator.Security.Dao.Specification;

public class ActionPermissionSpecification : AbstractSpecification<ActionPermission, ActionPermissionCriteria>
{
    public ActionPermissionSpecification(AppDbContext context) : base(context.ActionPermissions)
    {
    }

    protected override void ConstructPredicates()
    {
        AddPredicateId();

        AddPredicate(e => e.Reference.EqualsString(Criteria.Reference));
        AddPredicate(e => e.Reference.ContainsString(Criteria.ReferenceLike));
        AddPredicate(e => e.Libelle.EqualsString(Criteria.Libelle));
        AddPredicate(e => e.Libelle.ContainsString(Criteria.LibelleLike));
    }
}