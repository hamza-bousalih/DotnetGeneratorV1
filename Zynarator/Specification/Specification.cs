using DotnetGenerator.Zynarator.Bean;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerator.Zynarator.Specification;

public abstract class Specification<TEntity> where TEntity : BusinessObject
{
    protected IQueryable<TEntity> Query;

    protected List<Func<TEntity, bool>> Predicates = new();

    protected Specification(DbSet<TEntity> table)
    {
        Query = table.AsQueryable();
        Config();
    }

    private void Config()
    {
        Query = SetIncluded();
    }

    protected virtual IQueryable<TEntity> SetIncluded()
    {
        return Query;
    }

    protected void AddPredicate(Func<TEntity, bool> predicate) =>  Predicates.Add(predicate);
    
    protected void AddPredicateIf(bool condition, Func<TEntity, bool> predicate)
    {
        if (condition) AddPredicate(predicate);
    }

    public async Task<List<TEntity>> Search()
    {
        Func<TEntity, bool> predicate = e => true;
        if (Predicates.Count > 0) predicate = e => Predicates.TrueForAll(p => p.Invoke(e));
        var list = await Query.ToListAsync();
        return list.Where(e => predicate.Invoke(e)).ToList();
    }
}