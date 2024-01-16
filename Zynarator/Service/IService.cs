using DotnetGenerator.Zynarator.Bean;

namespace DotnetGenerator.Zynarator.Service;

public interface IService<TEntity> where TEntity : BusinessObject
{
    Task<List<TEntity>> FindAll();
    Task<int> Create(TEntity item);
    Task<int> Create(List<TEntity> items);
    Task<int> Update(TEntity item);
    Task<int> Update(List<TEntity> items);
    Task<TEntity> GetById(int id);
    Task<int> Delete(int id);
    Task<int> Delete(TEntity item);
    Task<int> Delete(List<TEntity> items);
}