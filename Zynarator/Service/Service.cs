using DotnetGenerator.Zynarator.Bean;
using DotnetGenerator.Zynarator.Criteria;
using DotnetGenerator.Zynarator.Repository;
using DotnetGenerator.Zynarator.Security.Dao.Repository;
using DotnetGenerator.Zynarator.Specification;
using DotnetGenerator.Zynarator.Util;
using Lamar;

namespace DotnetGenerator.Zynarator.Service;

public abstract class Service<TEntity, TRepository, TCriteria, TSpecification> : IService<TEntity, TCriteria>
    where TEntity : IBusinessObject
    where TRepository : IRepository<TEntity>
    where TCriteria : BaseCriteria
    where TSpecification : SpecificationHelper<TEntity, TCriteria>
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
        await Repository.FindById(id) ?? default;

    public virtual async Task<List<TEntity>> FindAll() =>
        await Repository.FindAll();

    public virtual async Task<TEntity?> Create(TEntity item, bool useTransaction = true)
    {
        return await Repository.TransactionBegin(
            async () =>
            {
                var loaded = item.Id == 0 ? default : await FindByReferenceEntity(item);
                if (loaded != null) return loaded;
                NullifyEntities(item);
                return await Repository.Save(item);
            },
            useTransaction
        );
    }

    public virtual async Task<List<TEntity>> Create(List<TEntity> items, bool useTransaction = true)
    {
        return await Repository.TransactionBegin(
            async () =>
            {
                var list = new List<TEntity>();
                foreach (var item in items)
                {
                    if (await FindByReferenceEntity(item) == null)
                    {
                        NullifyEntities(item);
                        await Repository.Save(item);
                    }
                    else list.Add(item);
                }

                return list;
            },
            useTransaction
        );
    }

    public virtual async Task<TEntity?> FindOrSave(TEntity? t, bool useTransaction = true)
    {
        return await Repository.TransactionBegin(
            async () =>
            {
                if (t == null) return t;
                await FindOrSaveAssociatedObject(t);
                var result = await FindByReferenceEntity(t);
                if (result != null) return result;
                NullifyEntities(t);
                return await Create(t);
            },
            useTransaction
        );
    }

    public virtual async Task<TEntity> Update(TEntity item, bool useTransaction = true)
    {
        return await Repository.TransactionBegin(
            async () =>
            {
                var loadedItem = item.Id == 0 ? default : await Repository.FindById(item.Id);
                if (loadedItem == null) throw new Exception("errors.notFound");
                NullifyEntities(item);
                await UpdateWithAssociatedLists(item);
                await Repository.Update(item);
                return loadedItem;
            },
            useTransaction
        );
    }

    public virtual async Task<List<TEntity>> Update(List<TEntity> items, bool createIfNotExist = true, bool useTransaction = true)
    {
        return await Repository.TransactionBegin(
            async () =>
            {
                var list = new List<TEntity>();
                foreach (var item in items)
                    if (item.Id == 0) await Repository.Update(item);
                    else
                    {
                        var loadedItem = await FindById(item.Id);
                        if (createIfNotExist && (item.Id == 0 || loadedItem == null))
                        {
                            NullifyEntities(item);
                            await Repository.Update(item);
                        }
                        else if (item.Id != 0 && loadedItem != null) await Repository.Update(item);
                        else list.Add(item);
                    }

                return list;
            },
            useTransaction
        );
    }

    public virtual async Task<int> DeleteById(long id, bool useTransaction = true)
    {
        return await Repository.TransactionBegin(
            async () =>
            {
                await DeleteAssociatedLists(id);
                return await Repository.DeleteById(id);
            },
            useTransaction
        );
    }

    public virtual async Task<int> Delete(TEntity item, bool useTransaction = true)
    {
        return await Repository.TransactionBegin(
            async () =>
            {
                await DeleteAssociatedLists(item.Id);
                return await Repository.Delete(item);
            },
            useTransaction
        );
    }

    public virtual async Task<int> Delete(List<TEntity> items, bool useTransaction = true)
    {
        return await Repository.TransactionBegin(
            async () =>
            {
                foreach (var item in items)
                {
                    await DeleteAssociatedLists(item.Id);
                    await Repository.Delete(item);
                }

                return items.Count;
            },
            useTransaction
        );
    }

    protected virtual async Task<TEntity?> FindByReferenceEntity(TEntity t)
    {
        return t.Id == 0 ? default : await FindById(t.Id);
    }

    public virtual async Task<TEntity?> FindWithAssociatedLists(long id)
    {
        return await FindById(id);
    }

    public virtual async Task DeleteWithAssociatedLists(TEntity t)
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