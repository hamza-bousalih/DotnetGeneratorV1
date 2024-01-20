using DotnetGenerator.Bean.Core;
using DotnetGenerator.Zynarator.Service;

namespace DotnetGenerator.Service.Facade;

public interface AchatItemService: IService<AchatItem>
{
    public Task<int> DeleteByAchatId(int id);
    public Task<int> DeleteByProduitId(int id);
    public Task<List<AchatItem>?> FindByAchatId(int id);
    public Task<List<AchatItem>?> FindByProduitId(int id);
}