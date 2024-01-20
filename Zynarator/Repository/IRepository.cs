using System.Linq.Expressions;
using DotnetGenerator.Zynarator.Audit;
using DotnetGenerator.Zynarator.Bean;

namespace DotnetGenerator.Zynarator.Repository;

public interface IRepository<TEntity> where TEntity : BusinessObject
{
    // Retrieve operations
    Task<TEntity?> FindById(int id);
    Task<List<TEntity>> FindAll();
    Task<List<TEntity>> Filter(Expression<Func<TEntity, bool>> predicate);

    // Create operations
    Task<TEntity> Save(TEntity entity);
    Task<List<TEntity>> Save(List<TEntity> entities);

    // Update operations
    Task<TEntity> Update(TEntity entity);
    Task<List<TEntity>> Update(List<TEntity> entities);

    // Delete operations
    Task<int> Delete(TEntity entity);
    Task<int> Delete(List<TEntity> entities);
    Task<int> DeleteById(int id);

    // Count operations
    Task<int> Count();
}