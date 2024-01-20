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

    public Task<int> DeleteByAchatId(int id) => Repository.DeleteByAchatId(id);

    public Task<int> DeleteByProduitId(int id) => Repository.DeleteByProduitId(id);

    public Task<List<AchatItem>?> FindByAchatId(int id) => Repository.FindByAchatId(id);

    public Task<List<AchatItem>?> FindByProduitId(int id) => Repository.FindByProduitId(id);
}