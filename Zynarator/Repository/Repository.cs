using System.Linq.Expressions;
using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Audit;
using DotnetGenerator.Zynarator.Bean;
using JasperFx.Core;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerator.Zynarator.Repository;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : AuditBusinessObject
{
    protected readonly AppDbContext Context;
    protected readonly IQueryable<TEntity> Table;
    protected IQueryable<TEntity> IncludedTable;

    public Repository(AppDbContext context, DbSet<TEntity> table)
    {
        Context = context;
        Table = table.AsQueryable();
        IncludedTable = SetIncluded();
    }

    protected virtual void SetContextEntry(TEntity item)
    {
    }

    protected virtual IQueryable<TEntity> SetIncluded() => Table;

    protected void SetUnchangedEntry<TProperty>(TProperty? property) where TProperty : BusinessObject
    {
        if (property is not null && property.Id != 0)
            Context.Entry(property).State = EntityState.Unchanged;
        // else if (property is not null)
        //     Context.Entry(property).State = EntityState.Detached;
    }

    protected void SetUnchangedEntry<TProperty>(IEnumerable<TProperty>? properties) where TProperty : BusinessObject
    {
        properties?.Each(SetUnchangedEntry);
    }

    protected async Task<int> DeleteIf(Expression<Func<TEntity, bool>> predicate) =>
        await Table.Where(predicate).ExecuteDeleteAsync();

    protected async Task<TEntity?> FindIf(Expression<Func<TEntity, bool>> predicate) =>
        await Table.FirstOrDefaultAsync(predicate);

    protected async Task<List<TEntity>?> FindListIf(Expression<Func<TEntity, bool>> predicate) =>
        await Table.Where(predicate).ToListAsync();

    public async Task<TEntity?> FindById(long id) =>
        await FindIf(i => i.Id == id);

    public async Task<List<TEntity>> FindAll() =>
        await IncludedTable.ToListAsync();

    public async Task<List<TEntity>> Filter(Expression<Func<TEntity, bool>> predicate)
    {
        return await IncludedTable.Where(predicate).ToListAsync();
    }

    public async Task<TEntity> Save(TEntity item)
    {
        Context.Add(item);
        SetContextEntry(item);
        await Context.SaveChangesAsync();
        return item;
    }

    public async Task<List<TEntity>> Save(List<TEntity> items)
    {
        Context.AddRange(items);
        foreach (var item in items) SetContextEntry(item);
        await Context.SaveChangesAsync();
        return items;
    }

    public async Task<TEntity> Update(TEntity item)
    {
        Context.Update(item);
        await Context.SaveChangesAsync();
        return item;
    }

    public async Task<List<TEntity>> Update(List<TEntity> items)
    {
        Context.UpdateRange(items);
        await Context.SaveChangesAsync();
        return items;
    }

    public async Task<int> DeleteById(long id) =>
        await DeleteIf(item => item.Id == id);

    public async Task<int> Delete(TEntity item) =>
        await DeleteById(item.Id);

    public async Task<int> Delete(List<TEntity> items) =>
        await DeleteIf(t => items.Map(i => i.Id).Contains(t.Id));

    public async Task<int> Count() => await Table.CountAsync();

    public async Task<List<TEntity>> FindPaginated(int page = 1, int size = 10)
    {
        return await Table
            .Skip(page == 0 ? 0 : (page - 1) * size)
            .Take(size)
            .ToListAsync();
    }

    public async Task<List<TEntity>> FindOptimized()
    {
        return await IncludedTable.Select(e => Optimized(e)).ToListAsync();
    }

    protected abstract TEntity Optimized(TEntity e);
}