using DotnetGenerator.Bean.Core;
using DotnetGenerator.Dao.Criteria;
using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Specification;
using JasperFx.Core;

namespace DotnetGenerator.Dao.Specification;

public class ProduitSpecification: AbstractSpecification<Produit, AchatCriteria>
{
    public ProduitSpecification(AppDbContext context) : base(context.Produits)
    {
    }
    
    protected  override void ConstructPredicates()
    {
        AddPredicateId();
    }
}