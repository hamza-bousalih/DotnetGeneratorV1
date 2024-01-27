using DotnetGenerator.Bean.Core;
using DotnetGenerator.Dao.Criteria;
using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Specification;
using JasperFx.Core;

namespace DotnetGenerator.Dao.Specification;

public class AchatItemSpecification: AbstractSpecification<AchatItem, AchatItemCriteria>
{
    public AchatItemSpecification(AppDbContext context) : base(context.AchatItems)
    {
    }
    
    protected override void ConstructPredicates()
    {
        AddPredicateId();
    }
}