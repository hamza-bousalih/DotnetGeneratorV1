using DotnetGenerator.Zynarator.Bean;
using DotnetGenerator.Zynarator.Criteria;
using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Util;

namespace DotnetGenerator.Zynarator.Service;

public interface IService<TEntity, TCriteria>
    where TEntity : IBusinessObject
    where TCriteria : BaseCriteria
{
    Task<TEntity?> FindById(long id);
    Task<List<TEntity>> FindAll();

    Task<TEntity?> Create(TEntity item, bool useTransaction = true);
    Task<List<TEntity>> Create(List<TEntity> items, bool useTransaction = true);

    Task<TEntity> Update(TEntity item, bool useTransaction = true);
    Task<List<TEntity>> Update(List<TEntity> items, bool createIfNotExist = true, bool useTransaction = true);

    Task<int> DeleteById(long id, bool useTransaction = true);
    Task<int> Delete(TEntity item, bool useTransaction = true);
    Task<int> Delete(List<TEntity> items, bool useTransaction = true);


    Task<List<TEntity>> FindByCriteria(TCriteria criteria);

    Task<PaginatedList<TEntity>> FindPaginatedByCriteria(TCriteria criteria);
    Task<List<TEntity>> FindOptimized();

    List<List<TEntity>> GetToBeSavedAndToBeDeleted(List<TEntity>? oldList, List<TEntity>? newList)
    {
        return FilterLists.GetToBeSavedAndToBeDeleted(oldList, newList);
    }
}