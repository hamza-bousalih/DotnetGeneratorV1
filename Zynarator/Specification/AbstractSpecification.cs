using DotnetGenerator.Zynarator.Bean;
using DotnetGenerator.Zynarator.Criteria;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerator.Zynarator.Specification;

public abstract class AbstractSpecification<TEntity, TCriteria> : SpecificationHelper<TEntity, TCriteria>
    where TEntity : BusinessObject
    where TCriteria : BaseCriteria
{
    protected AbstractSpecification(DbSet<TEntity> table): base(table.AsQueryable())
    {
    }

    public override void DefinePredicates()
    {
        Predicates = new List<Func<TEntity, bool>>();
        ConstructPredicates();
    }

    protected abstract void ConstructPredicates();
}