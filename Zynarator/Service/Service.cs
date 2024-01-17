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
    
    public virtual async Task<TEntity> FindById(int id) => 
        await Repository.FindById(id) ?? throw new Exception("No Instance Found For id: " + id);
    
    public virtual async Task<int> Create(TEntity item) => 
        await Repository.Save(item);
    
    public virtual async Task<int> Create(List<TEntity> items) => 
        await Repository.Save(items);
    
    public virtual async Task<List<TEntity>> FindAll() => 
        await Repository.FindAll();
    
    public virtual async Task<int> Update(TEntity item) => 
        await Repository.Update(item);
    
    public virtual async Task<int> Update(List<TEntity> items) =>
        await Repository.Update(items);
    
    public virtual async Task<int> DeleteById(int id) => 
        await Repository.DeleteById(id);
    
    public virtual async Task<int> Delete(TEntity item) => 
        await Repository.Delete(item);
    
    public virtual async Task<int> Delete(List<TEntity> items) => 
        await Repository.Delete(items);
}