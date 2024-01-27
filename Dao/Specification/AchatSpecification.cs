using DotnetGenerator.Bean.Core;
using DotnetGenerator.Dao.Criteria;
using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Specification;
using JasperFx.Core;

namespace DotnetGenerator.Dao.Specification;

public class AchatSpecification: AbstractSpecification<Achat, AchatCriteria>
{
    public AchatSpecification(AppDbContext context) : base(context.Achats)
    {
    }
    
    protected  override void ConstructPredicates()
    {
        AddPredicateId();

        AddPredicate(e => e.Reference.EqualsString(Criteria.Reference));
        AddPredicate(e => e.Reference.ContainsString(Criteria.ReferenceLike));

        AddPredicate(e => e.Description.ContainsString(Criteria.Description));
        AddPredicate(e => e.Description.ContainsString(Criteria.DescriptionLike));

        AddPredicate(e => e.Total.EqualsDecimal(Criteria.Total));
        AddPredicate(e => e.Total.GreaterThen(Criteria.TotalMin));
        AddPredicate(e => e.Total.LessThen(Criteria.TotalMax));

        AddPredicate(e => e.TotalPaye.EqualsDecimal(Criteria.TotalPaye));
        AddPredicate(e => e.TotalPaye.GreaterThen(Criteria.TotalPayeMin));
        AddPredicate(e => e.TotalPaye.LessThen(Criteria.TotalPayeMax));

        AddPredicate(e => e.DateAchat.EqualsDate(Criteria.DateAchat));
        AddPredicate(e => e.DateAchat.From(Criteria.DateAchatFrom));
        AddPredicate(e => e.DateAchat.To(Criteria.DateAchatTo));

        AddPredicateIf(Criteria.Client is not null, e => e.Client!.Id == Criteria.Client!.Id);
        AddPredicateIf(Criteria.Clients is not null, e => e.Client!.Id.In(Criteria.Clients!.Ids()));
        AddPredicateIf(Criteria.Client is not null, e => e.Client!.Cin == Criteria.Client!.Cin);
    }
}