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

    public async Task<List<TEntity>> PaginatedSearch()
    {
        var result = await Search();
        var start = Criteria.Page * Criteria.MaxResults;
        var count = Criteria.MaxResults;
        return result.GetRange(count, start);
    }

    protected bool IdEquals(TEntity entity) => entity.Id == Criteria!.Id;

    protected void AddPredicateId()
    {
        AddPredicateIf(Criteria.Id is not null && Criteria.Id != 0, e => e.Id.Equals(Criteria.Id));
        AddPredicateIf(Criteria.NotId is not null && Criteria.NotId != 0, e => !e.Id.Equals(Criteria.NotId));
        AddPredicateIf(Criteria.IdsIn is not null && Criteria.IdsIn?.Count > 0, e => e.Id.In(Criteria.IdsIn));
        AddPredicateIf(Criteria.IdsNotIn is not null && Criteria.IdsNotIn?.Count > 0,
            e => e.Id.NotIn(Criteria.IdsNotIn));
    }
}