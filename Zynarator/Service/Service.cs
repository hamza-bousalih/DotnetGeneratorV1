using DotnetGenerator.Zynarator.Bean;
using DotnetGenerator.Zynarator.Criteria;
using DotnetGenerator.Zynarator.Repository;
using DotnetGenerator.Zynarator.Specification;
using DotnetGenerator.Zynarator.Util;
using Lamar;

namespace DotnetGenerator.Zynarator.Service;

public abstract class Service<TEntity, TRepository, TCriteria, TSpecification> : IService<TEntity, TCriteria>
    where TEntity : BusinessObject
    where TRepository : IRepository<TEntity>
    where TCriteria : BaseCriteria
    where TSpecification : AbstractSpecification<TEntity, TCriteria>
{
    protected TRepository Repository;
    protected readonly TSpecification Specification;

    protected Type ItemClass;
    protected Type SpecificationClass;

    protected Service(IContainer container)
    {
        Repository = container.GetInstance<TRepository>();
        Specification = container.GetInstance<TSpecification>();
        ItemClass = typeof(TEntity);
        SpecificationClass = typeof(TSpecification);
    }

    public virtual async Task<TEntity?> FindById(long id) =>
        await Repository.FindById(id) ?? null;

    public virtual async Task<List<TEntity>> FindAll() =>
        await Repository.FindAll();

    public virtual async Task<List<TEntity>> FindPaginated(int page, int size) =>
        await Repository.FindPaginated(page, size);

    public virtual async Task<TEntity> Create(TEntity item)
    {
        var loaded = item.Id != 0 ? null : await FindByReference(item);
        if (loaded == null) return await Repository.Save(item);
        return loaded;
    }

    public virtual async Task<List<TEntity>> Create(List<TEntity> items)
    {
        var list = new List<TEntity>();
        foreach (var item in items)
        {
            if (await FindByReference(item) != null)
                await Repository.Save(item);
            else list.Add(item);
        }

        return list;
    }

    public virtual async Task<TEntity?> FindOrSave(TEntity? t)
    {
        if (t == null) return t;
        await FindOrSaveAssociatedObject(t);
        var result = await FindByReference(t);
        if (result == null) return await Create(t);
        return result;
    }

    public virtual async Task<TEntity> Update(TEntity item)
    {
        var loadedItem = item.Id == 0 ? null : await Repository.FindById(item.Id);
        if (loadedItem == null) throw new Exception("errors.notFound");
        await UpdateWithAssociatedLists(item);
        await Repository.Update(item);
        return loadedItem;
    }

    public virtual async Task<List<TEntity>> Update(List<TEntity> items, bool createIfNotExist = true)
    {
        var list = new List<TEntity>();
        foreach (var item in items)
            if (item.Id == 0) await Repository.Update(item);
            else
            {
                var loadedItem = await FindById(item.Id);
                if (createIfNotExist && (item.Id == 0 || loadedItem == null)) await Repository.Update(item);
                else if (item.Id != 0 && loadedItem != null) await Repository.Update(item);
                else list.Add(item);
            }

        return list;
    }

    public virtual async Task<int> DeleteById(long id)
    {
        await DeleteAssociatedLists(id);
        return await Repository.DeleteById(id);
    }

    public virtual async Task<int> Delete(TEntity item)
    {
        await DeleteAssociatedLists(item.Id);
        return await Repository.Delete(item);
    }

    public virtual async Task<int> Delete(List<TEntity> items)
    {
        foreach (var item in items)
        {
            await DeleteAssociatedLists(item.Id);
            await Repository.Delete(item);
        }

        return items.Count;
    }

    protected virtual async Task<TEntity?> FindByReference(TEntity t)
    {
        return t.Id == 0 ? null : await FindById(t.Id);
    }

    public async Task<TEntity?> FindWithAssociatedLists(long id)
    {
        return await FindById(id);
    }

    public async Task DeleteWithAssociatedLists(TEntity t)
    {
        await DeleteAssociatedLists(t.Id);
        await Delete(t);
    }

    protected virtual async Task DeleteAssociatedLists(long id)
    {
    }

    protected virtual async Task UpdateWithAssociatedLists(TEntity item)
    {
    }

    protected virtual async Task FindOrSaveAssociatedObject(TEntity item)
    {
    }

    protected virtual void NullifyEntities(TEntity item)
    {
    }
    // specification
    public async Task<List<TEntity>> FindByCriteria(TCriteria criteria)
    {
        Specification.Criteria = criteria;
        Specification.DefinePredicates();
        return await Specification.Search();
    }

    public async Task<PaginatedList<TEntity>> FindPaginatedByCriteria(TCriteria criteria)
    {
        Specification.Criteria = criteria;
        Specification.DefinePredicates();
        var paginatedSearch = await Specification.PaginatedSearch();
        return paginatedSearch;
    }

    public async Task<List<TEntity>> FindOptimized()
    {
        return await Repository.FindOptimized();
    }
}