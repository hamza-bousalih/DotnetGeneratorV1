using DotnetGenerator.Bean.Core;
using DotnetGenerator.Dao.Criteria;
using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Specification;
using JasperFx.Core;

namespace DotnetGenerator.Dao.Specification;

public class AchatItemSpecification : AbstractSpecification<AchatItem, AchatItemCriteria>
{
    public AchatItemSpecification(AppDbContext context) : base(context.AchatItems)
    {
    }

    protected override void ConstructPredicates()
    {
        AddPredicateId();

        AddPredicate(e => e.PrixUnitaire.EqualsDecimal(Criteria.PrixUnitaire));
        AddPredicate(e => e.PrixUnitaire.GreaterThen(Criteria.PrixUnitaireMin));
        AddPredicate(e => e.PrixUnitaire.LessThen(Criteria.PrixUnitaireMax));
        AddPredicate(e => e.PrixVente.EqualsDecimal(Criteria.PrixVente));
        AddPredicate(e => e.PrixVente.GreaterThen(Criteria.PrixVenteMin));
        AddPredicate(e => e.PrixVente.LessThen(Criteria.PrixVenteMax));
        AddPredicate(e => e.Quantite.EqualsDecimal(Criteria.Quantite));
        AddPredicate(e => e.Quantite.GreaterThen(Criteria.QuantiteMin));
        AddPredicate(e => e.Quantite.LessThen(Criteria.QuantiteMax));
        AddPredicate(e => e.QuantiteAvoir.EqualsDecimal(Criteria.QuantiteAvoir));
        AddPredicate(e => e.QuantiteAvoir.GreaterThen(Criteria.QuantiteAvoirMin));
        AddPredicate(e => e.QuantiteAvoir.LessThen(Criteria.QuantiteAvoirMax));
        AddPredicate(e => e.Remise.EqualsDecimal(Criteria.Remise));
        AddPredicate(e => e.Remise.GreaterThen(Criteria.RemiseMin));
        AddPredicate(e => e.Remise.LessThen(Criteria.RemiseMax));

        AddPredicateIf(Criteria.Produit is not null, e => e.Produit!.Id == Criteria.Produit!.Id);
        AddPredicateIf(Criteria.Produits is not null, e => e.Produit!.Id.In(Criteria.Produits!.Ids()));
        AddPredicateIf(Criteria.Produit is not null, e => e.Produit!.Reference == Criteria.Produit!.Reference);
        AddPredicateIf(Criteria.Achat is not null, e => e.Achat!.Id == Criteria.Achat!.Id);
        AddPredicateIf(Criteria.Achats is not null, e => e.Achat!.Id.In(Criteria.Achats!.Ids()));
        AddPredicateIf(Criteria.Achat is not null, e => e.Achat!.Reference == Criteria.Achat!.Reference);
    }
}