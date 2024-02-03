using DotnetGenerator.Zynarator.Bean;
using DotnetGenerator.Zynarator.Criteria;
using DotnetGenerator.Zynarator.Util;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerator.Zynarator.Specification;

public abstract class SpecificationHelper<TEntity, TCriteria> : Specification<TEntity>
    where TEntity : BusinessObject
    where TCriteria : BaseCriteria
{
    public required TCriteria Criteria;
    protected bool Distinct;

    protected SpecificationHelper(DbSet<TEntity> table) : base(table)
    {
    }

    public async Task<PaginatedList<TEntity>> PaginatedSearch()
    {
        var result = await Search();

        var start = Math.Clamp(Criteria.Page * Criteria.MaxResults, 0, result.Count - 1);
        var count = Math.Clamp(Criteria.MaxResults, 0, result.Count - start);

        return new PaginatedList<TEntity>()
        {
            List = result.GetRange(start, count),
            DataSize = result.Count
        };
    }

    protected void AddPredicateId()
    {
        AddPredicateIf(Criteria.Id is not null && Criteria.Id != 0, e => e.Id.Equals(Criteria.Id));
        AddPredicateIf(Criteria.NotId is not null && Criteria.NotId != 0, e => !e.Id.Equals(Criteria.NotId));
        AddPredicateIf(Criteria.IdsIn is not null && Criteria.IdsIn?.Count > 0, e => e.Id.In(Criteria.IdsIn));
        AddPredicateIf(Criteria.IdsNotIn is not null && Criteria.IdsNotIn?.Count > 0,
            e => e.Id.NotIn(Criteria.IdsNotIn));
    }
}