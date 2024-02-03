using DotnetGenerator.Zynarator.Bean;
using DotnetGenerator.Zynarator.Criteria;
using DotnetGenerator.Zynarator.Util;

namespace DotnetGenerator.Zynarator.Service;

public interface IService<TEntity, TCriteria> 
    where TEntity : BusinessObject
    where TCriteria : BaseCriteria
{
    Task<TEntity?> FindById(long id);
    Task<List<TEntity>> FindAll();
    Task<List<TEntity>> FindPaginated(int page, int size);
    
    Task<TEntity> Create(TEntity item);
    Task<List<TEntity>> Create(List<TEntity> items);
    
    Task<TEntity> Update(TEntity item);
    Task<List<TEntity>> Update(List<TEntity> items, bool createIfNotExist = true);
    
    Task<int> DeleteById(long id);
    Task<int> Delete(TEntity item);
    Task<int> Delete(List<TEntity> items);
    
    

    Task<List<TEntity>> FindByCriteria(TCriteria criteria);

    Task<PaginatedList<TEntity>> FindPaginatedByCriteria(TCriteria criteria);
    Task<List<TEntity>> FindOptimized();
}