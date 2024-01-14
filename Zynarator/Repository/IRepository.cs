using System.Linq.Expressions;
using DotnetGenerator.Zynarator.Audit;

namespace DotnetGenerator.Zynarator.Repository;

public interface IRepository<TEntity> where TEntity : AuditBusinessObject
{
    // Retrieve operations
    Task<TEntity?> FindById(int id);
    Task<List<TEntity>?> FindAll();
    Task<List<TEntity>?> Filter(Expression<Func<TEntity, bool>> predicate);

    // Create operations
    Task<int> Save(TEntity entity);
    Task<int> Save(List<TEntity> entities);

    // Update operations
    Task<int> Update(TEntity entity);
    Task<int> Update(List<TEntity> entities);

    // Delete operations
    Task<int> Delete(TEntity entity);
    Task<int> Delete(List<TEntity> entities);
    Task<int> DeleteById(int id);

    // Count operations
    Task<int> Count();
}