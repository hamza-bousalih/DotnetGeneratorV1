using DotnetGenerator.Bean.Core;
using DotnetGenerator.Dao.Criteria;
using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Specification;
using JasperFx.Core;

namespace DotnetGenerator.Dao.Specification;

public class ProduitSpecification : AbstractSpecification<Produit, ProduitCriteria>
{
    public ProduitSpecification(AppDbContext context) : base(context.Produits)
    {
    }

    protected override void ConstructPredicates()
    {
        AddPredicateId();

        AddPredicate(e => e.Reference.EqualsString(Criteria.Reference));
        AddPredicate(e => e.Reference.ContainsString(Criteria.ReferenceLike));
        AddPredicate(e => e.Libelle.EqualsString(Criteria.Libelle));
        AddPredicate(e => e.Libelle.ContainsString(Criteria.LibelleLike));
        AddPredicate(e => e.Barcode.EqualsString(Criteria.Barcode));
        AddPredicate(e => e.Barcode.ContainsString(Criteria.BarcodeLike));
        AddPredicate(e => e.Discription.EqualsString(Criteria.Discription));
        AddPredicate(e => e.Discription.ContainsString(Criteria.DiscriptionLike));
        AddPredicate(e => e.PrixAchatMoyen.EqualsDecimal(Criteria.PrixAchatMoyen));
        AddPredicate(e => e.PrixAchatMoyen.GreaterThen(Criteria.PrixAchatMoyenMin));
        AddPredicate(e => e.PrixAchatMoyen.LessThen(Criteria.PrixAchatMoyenMax));
        AddPredicate(e => e.Quantite.EqualsDecimal(Criteria.Quantite));
        AddPredicate(e => e.Quantite.GreaterThen(Criteria.QuantiteMin));
        AddPredicate(e => e.Quantite.LessThen(Criteria.QuantiteMax));
        AddPredicate(e => e.SeuilAlert.EqualsDecimal(Criteria.SeuilAlert));
        AddPredicate(e => e.SeuilAlert.GreaterThen(Criteria.SeuilAlertMin));
        AddPredicate(e => e.SeuilAlert.LessThen(Criteria.SeuilAlertMax));
    }
}