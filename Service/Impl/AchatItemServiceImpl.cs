using DotnetGenerator.Bean.Core;
using DotnetGenerator.Dao.Criteria;
using DotnetGenerator.Dao.Facade;
using DotnetGenerator.Dao.Specification;
using DotnetGenerator.Service.Facade;
using DotnetGenerator.Zynarator.Service;
using Lamar;

namespace DotnetGenerator.Service.Impl;

public class AchatItemServiceImpl: Service<AchatItem, AchatItemDao, AchatItemCriteria, AchatItemSpecification>, AchatItemService
{
    public AchatItemServiceImpl(IContainer container) : base(container)
    {
    }

    public Task<int> DeleteByAchatId(long id)
    {
        return Repository.DeleteByAchatId(id);
    }

    public Task<int> DeleteByProduitId(long id)
    {
        return Repository.DeleteByProduitId(id);
    }

    public Task<List<AchatItem>?> FindByAchatId(long id)
    {
        return Repository.FindByAchatId(id);
    }

    public Task<List<AchatItem>?> FindByProduitId(long id)
    {
        return Repository.FindByProduitId(id);
    }
}