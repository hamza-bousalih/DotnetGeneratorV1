using System.Collections.ObjectModel;
using System.Linq.Expressions;
using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Audit;
using DotnetGenerator.Zynarator.Bean;
using JasperFx.Core;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerator.Zynarator.Repository;

public class Repository<TEntity>: IRepository<TEntity> where TEntity : AuditBusinessObject
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

    protected void SetEntry<TProperty>(TProperty? property) where TProperty : BusinessObject
    {
        if (property != null && property.Id != 0)
            Context.Entry(property).State = EntityState.Unchanged;
    }
    
    protected void SetEntry<TProperty>(IEnumerable<TProperty> properties) where TProperty : BusinessObject => 
        properties.Each(SetEntry);

    public async Task<TEntity?> FindById(int id) => 
        await IncludedTable.FirstOrDefaultAsync(i => i.Id == id);

    public async Task<List<TEntity>?> FindAll() =>
        await IncludedTable.ToListAsync();

    public async Task<List<TEntity>?> Filter(Expression<Func<TEntity, bool>> predicate) =>
        await IncludedTable.Where(predicate).ToListAsync();
    
    public async Task<int> Save(TEntity item)
    {
        Context.Add(item);
        SetContextEntry(item);
        return await Context.SaveChangesAsync();
    }

    public async Task<int> Save(List<TEntity> items)
    {
        Context.AddRange(items);
        foreach (var item in items) SetContextEntry(item);
        return await Context.SaveChangesAsync();
    }

    public async Task<int> Update(TEntity item)
    {
        Context.Update(item);
        return await Context.SaveChangesAsync();
    }

    public async Task<int> Update(List<TEntity> items)
    {
        Context.UpdateRange(items);
        return await Context.SaveChangesAsync();
    }

    protected async Task<int> DeleteIf(Expression<Func<TEntity, bool>> predicate) => 
        await Table.Where(predicate).ExecuteDeleteAsync();

    public async Task<int> DeleteById(int id) =>
        await DeleteIf(item => item.Id == id);
    
    public async Task<int> Delete(TEntity item) => 
        await DeleteById(item.Id);

    public async Task<int> Delete(List<TEntity> items) =>
        await DeleteIf(t => items.Map(i => i.Id).Contains(t.Id));


    public async Task<int> Count() => await Table.CountAsync();
}