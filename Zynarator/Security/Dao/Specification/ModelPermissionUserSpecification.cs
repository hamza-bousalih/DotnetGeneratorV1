using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Dao.Criteria;
using DotnetGenerator.Zynarator.Specification;

namespace DotnetGenerator.Zynarator.Security.Dao.Specification;

public class ModelPermissionUserSpecification : AbstractSpecification<ModelPermissionUser, ModelPermissionUserCriteria>
{
    public ModelPermissionUserSpecification(AppDbContext context) : base(context.ModelPermissionUsers)
    {
    }

    protected override void ConstructPredicates()
    {
        AddPredicateId();

        AddPredicateIf(Criteria.Value is not null, e => e.Value == Criteria.Value);
        AddPredicate(e => e.SubAttribute.EqualsString(Criteria.SubAttribute));
        AddPredicate(e => e.SubAttribute.ContainsString(Criteria.SubAttributeLike));

        AddPredicateIf(Criteria.ActionPermission is not null,
            e => e.ActionPermission!.Id == Criteria.ActionPermission!.Id);
        AddPredicateIf(Criteria.ActionPermissions is not null,
            e => e.ActionPermission!.Id.In(Criteria.ActionPermissions!.Ids()));
        AddPredicateIf(Criteria.ActionPermission is not null,
            e => e.ActionPermission!.Reference == Criteria.ActionPermission!.Reference);
        AddPredicateIf(Criteria.ModelPermission is not null,
            e => e.ModelPermission!.Id == Criteria.ModelPermission!.Id);
        AddPredicateIf(Criteria.ModelPermissions is not null,
            e => e.ModelPermission!.Id.In(Criteria.ModelPermissions!.Ids()));
        AddPredicateIf(Criteria.ModelPermission is not null,
            e => e.ModelPermission!.Reference == Criteria.ModelPermission!.Reference);
        AddPredicateIf(Criteria.User is not null, e => e.User!.Id == Criteria.User!.Id);
        AddPredicateIf(Criteria.Users is not null, e => e.User!.Id.In(Criteria.Users!.Ids()));
        AddPredicateIf(Criteria.User is not null, e => e.User!.UserName == Criteria.User!.Username);
    }
}