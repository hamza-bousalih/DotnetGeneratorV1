using DotnetGenerator.Bean.Core;
using DotnetGenerator.Dao.Criteria;
using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Specification;
using JasperFx.Core;

namespace DotnetGenerator.Dao.Specification;

public class ClientSpecification : AbstractSpecification<Client, ClientCriteria>
{
    public ClientSpecification(AppDbContext context) : base(context.Clients)
    {
    }

    protected override void ConstructPredicates()
    {
        AddPredicateId();

        AddPredicate(e => e.Cin.EqualsString(Criteria.Cin));
        AddPredicate(e => e.Cin.ContainsString(Criteria.CinLike));
        AddPredicate(e => e.Nom.EqualsString(Criteria.Nom));
        AddPredicate(e => e.Nom.ContainsString(Criteria.NomLike));
        AddPredicate(e => e.Tel.EqualsString(Criteria.Tel));
        AddPredicate(e => e.Tel.ContainsString(Criteria.TelLike));
        AddPredicate(e => e.Email.EqualsString(Criteria.Email));
        AddPredicate(e => e.Email.ContainsString(Criteria.EmailLike));
        AddPredicate(e => e.Adresse.EqualsString(Criteria.Adresse));
        AddPredicate(e => e.Adresse.ContainsString(Criteria.AdresseLike));
        AddPredicate(e => e.Description.EqualsString(Criteria.Description));
        AddPredicate(e => e.Description.ContainsString(Criteria.DescriptionLike));
        AddPredicate(e => e.Creance.EqualsDecimal(Criteria.Creance));
        AddPredicate(e => e.Creance.GreaterThen(Criteria.CreanceMin));
        AddPredicate(e => e.Creance.LessThen(Criteria.CreanceMax));
    }
}