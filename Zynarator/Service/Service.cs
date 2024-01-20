using DotnetGenerator.Zynarator.Bean;
using DotnetGenerator.Zynarator.Repository;
using Lamar;

namespace DotnetGenerator.Zynarator.Service;

public abstract class Service<TEntity, TRepository>: IService<TEntity>
    where TEntity : BusinessObject
    where TRepository : IRepository<TEntity>
{
    protected TRepository Repository;
    
    protected Service(IContainer container) => Repository = container.GetInstance<TRepository>();
    
    public virtual async Task<TEntity> FindById(long id) => 
        await Repository.FindById(id) ?? throw new Exception("No Instance Found For id: " + id);

    public virtual async Task<TEntity> Create(TEntity item)
    {
        var loaded = await FindByReferenceEntity(item);
        if (loaded == null) return await Repository.Save(item);
        return loaded;
    }
    
    public virtual async Task<List<TEntity>> Create(List<TEntity> items)
    {
        var list = new List<TEntity>();
        foreach (var item in items)
        {
            var founded = await FindByReferenceEntity(item);
            if (founded == null)
                //TODO findOrSaveAssociatedObject(t);
                await Repository.Save(item);
            else list.Add(founded);
        }
        return list;
    }

    public virtual async Task<List<TEntity>> FindAll() => 
        await Repository.FindAll();
    
    public virtual async Task<TEntity> Update(TEntity item)
    {
        var loadedItem = await Repository.FindById(item.Id);
        if (loadedItem == null) throw new Exception("errors.notFound");
        //TODO UpdateWithAssociatedLists(t);
        await Repository.Update(item);
        return loadedItem;
    }

    public virtual async Task<List<TEntity>> Update(List<TEntity> items)
    {
        return await Repository.Update(items);
    }

    public virtual async Task<int> DeleteById(long id)
    {
        await DeleteAssociatedLists(id);
        return await Repository.DeleteById(id);
    }

    public virtual async Task<int> Delete(TEntity item) => 
        await Repository.Delete(item);
    
    public virtual async Task<int> Delete(List<TEntity> items) => 
        await Repository.Delete(items);
    
    protected virtual async Task<TEntity?> FindByReferenceEntity(TEntity t) {
        return t.Id == 0 ? null : await FindById(t.Id);
    }
    
    protected virtual Task DeleteAssociatedLists(long id) => Task.CompletedTask;
}