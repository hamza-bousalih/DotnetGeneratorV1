using DotnetGenerator.Zynarator.Bean;
using DotnetGenerator.Zynarator.Criteria;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerator.Zynarator.Specification;

public abstract class SpecificationHelper<TEntity, TCriteria> : Specification<TEntity>
    where TEntity : BusinessObject
    where TCriteria : BaseCriteria
{
    public TCriteria Criteria;
    protected bool Distinct;

    protected SpecificationHelper(DbSet<TEntity> table) : base(table)
    {
    }

    protected bool IdEquals(TEntity entity) => entity.Id == Criteria!.Id;

    protected void AddPredicateId()
    {
        AddPredicateIf(Criteria.Id != 0, e => e.Id == Criteria.Id);
        AddPredicateIf(Criteria.NotId != 0, e => e.Id != Criteria.NotId);
        AddPredicateIf(Criteria.IdsIn?.Count > 0, e => e.Id.In(Criteria.IdsIn));
        AddPredicateIf(Criteria.IdsNotIn?.Count > 0, e => e.Id.NotIn(Criteria.IdsIn));
    }
}