using DotnetGenerator.Zynarator.Bean;

namespace DotnetGenerator.Zynarator.Service;

public interface IService<TEntity> where TEntity : BusinessObject
{
    Task<List<TEntity>> FindAll();
    Task<TEntity> Create(TEntity item);
    Task<List<TEntity>> Create(List<TEntity> items);
    Task<TEntity> Update(TEntity item);
    Task<List<TEntity>> Update(List<TEntity> items);
    Task<TEntity> FindById(long id);
    Task<int> DeleteById(long id);
    Task<int> Delete(TEntity item);
    Task<int> Delete(List<TEntity> items);
}