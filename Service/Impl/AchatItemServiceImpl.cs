using DotnetGenerator.Bean.Core;
using DotnetGenerator.Dao.Facade;
using DotnetGenerator.Service.Facade;
using DotnetGenerator.Zynarator.Service;
using Lamar;

namespace DotnetGenerator.Service.Impl;

public class AchatItemServiceImpl: Service<AchatItem, AchatItemDao>, AchatItemService
{
    public AchatItemServiceImpl(IContainer container) : base(container)
    {
    }

    public Task<int> DeleteByAchatId(long id) => Repository.DeleteByAchatId(id);

    public Task<int> DeleteByProduitId(long id) => Repository.DeleteByProduitId(id);

    public Task<List<AchatItem>?> FindByAchatId(long id) => Repository.FindByAchatId(id);

    public Task<List<AchatItem>?> FindByProduitId(long id) => Repository.FindByProduitId(id);
}