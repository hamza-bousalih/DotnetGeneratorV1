using System.Linq.Expressions;
using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Bean;
using JasperFx.Core;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerator.Zynarator.Repository;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : IBusinessObject
{
    public AppDbContext Context { get; }
    protected readonly IQueryable<TEntity> Table;
    protected IQueryable<TEntity> IncludedTable;

    protected Repository(AppDbContext context, IQueryable<TEntity> table)
    {
        Context = context;
        Table = table;
        Config();
    }

    private void Config()
    {
        IncludedTable = SetIncluded();
    }

    protected virtual void SetContextEntry(TEntity item)
    {
    }

    protected virtual IQueryable<TEntity> SetIncluded() => Table;

    protected void SetUnchangedEntry<TProperty>(TProperty? property) where TProperty : IBusinessObject
    {
        if (property is not null && property.Id != 0)
            Context.Entry(property).State = EntityState.Unchanged;
    }

    protected void SetUnchangedEntry<TProperty>(IEnumerable<TProperty>? properties) where TProperty : IBusinessObject
    {
        properties?.Each(SetUnchangedEntry);
    }

    protected async Task<int> DeleteIf(Expression<Func<TEntity, bool>> predicate) =>
        await Table.Where(predicate).ExecuteDeleteAsync();

    protected async Task<TEntity?> FindIf(Expression<Func<TEntity, bool>> predicate) =>
        await IncludedTable.FirstOrDefaultAsync(predicate);

    protected async Task<List<TEntity>?> FindListIf(Expression<Func<TEntity, bool>> predicate) =>
        await IncludedTable.Where(predicate).ToListAsync();

    public virtual async Task<TEntity?> FindById(long id) =>
        await FindIf(i => i.Id == id);

    public virtual async Task<List<TEntity>> FindAll() =>
        await IncludedTable.ToListAsync();

    public virtual async Task<TEntity> Save(TEntity item)
    {
        Context.Add(item);
        SetContextEntry(item);
        await Context.SaveChangesAsync();
        return item;
    }

    public virtual async Task<List<TEntity>> Save(List<TEntity> items)
    {
        Context.AddRange(items);
        foreach (var item in items) SetContextEntry(item);
        await Context.SaveChangesAsync();
        return items;
    }

    public virtual async Task<TEntity> Update(TEntity item)
    {
        Context.Update(item);
        await Context.SaveChangesAsync();
        return item;
    }

    public virtual async Task<List<TEntity>> Update(List<TEntity> items)
    {
        Context.UpdateRange(items);
        await Context.SaveChangesAsync();
        return items;
    }

    public virtual async Task<int> DeleteById(long id) =>
        await DeleteIf(item => item.Id == id);

    public virtual async Task<int> Delete(TEntity item) =>
        await DeleteById(item.Id);

    public virtual async Task<int> Delete(List<TEntity> items) =>
        await DeleteIf(t => items.Map(i => i.Id).Contains(t.Id));

    public async Task<int> Count() => await Table.CountAsync();

    public virtual async Task<List<TEntity>> FindOptimized()
    {
        return await IncludedTable.ToListAsync();
    }
}