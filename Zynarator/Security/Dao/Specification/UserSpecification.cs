using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Dao.Criteria;
using DotnetGenerator.Zynarator.Specification;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerator.Zynarator.Security.Dao.Specification;

public class UserSpecification : SpecificationHelper<User, UserCriteria>
{
    public UserSpecification(UserManager<User> userManager): base(userManager.Users)
    {
    }

    protected override IQueryable<User> SetIncluded()
    {
        return Query
            .Include(u => u.ModelPermissionUsers)!
                .ThenInclude(mpu => mpu.ModelPermission)
            .Include(u => u.ModelPermissionUsers)!
                .ThenInclude(mpu => mpu.ActionPermission)
            .Include(u => u.RoleUsers)!
                .ThenInclude(ru => ru.Role);
    }

    public override void DefinePredicates()
    {
        Predicates = new List<Func<User, bool>>();
        ConstructPredicates();
    }


    protected void ConstructPredicates()
    {
        AddPredicateId();

        AddPredicateIf(Criteria.CredentialsNonExpired is not null,
            e => e.CredentialsNonExpired == Criteria.CredentialsNonExpired);
        AddPredicateIf(Criteria.Enabled is not null, e => e.Enabled == Criteria.Enabled);
        AddPredicate(e => e.Email.EqualsString(Criteria.Email));
        AddPredicate(e => e.Email.ContainsString(Criteria.EmailLike));
        AddPredicateIf(Criteria.AccountNonExpired is not null, e => e.AccountNonExpired == Criteria.AccountNonExpired);
        AddPredicateIf(Criteria.AccountNonLocked is not null, e => e.AccountNonLocked == Criteria.AccountNonLocked);
        AddPredicate(e => e.UserName.EqualsString(Criteria.Username));
        AddPredicate(e => e.UserName.ContainsString(Criteria.UsernameLike));
        AddPredicate(e => e.Password.EqualsString(Criteria.Password));
        AddPredicate(e => e.Password.ContainsString(Criteria.PasswordLike));
        AddPredicateIf(Criteria.PasswordChanged is not null, e => e.PasswordChanged == Criteria.PasswordChanged);
        AddPredicate(e => e.LastName.EqualsString(Criteria.LastName));
        AddPredicate(e => e.LastName.ContainsString(Criteria.LastNameLike));
        AddPredicate(e => e.FirstName.EqualsString(Criteria.FirstName));
        AddPredicate(e => e.FirstName.ContainsString(Criteria.FirstNameLike));
        AddPredicate(e => e.Phone.EqualsString(Criteria.Phone));
        AddPredicate(e => e.Phone.ContainsString(Criteria.PhoneLike));
    }
}