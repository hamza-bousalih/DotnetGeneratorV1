using DotnetGenerator.Bean.Core;
using DotnetGenerator.Dao.Criteria;
using DotnetGenerator.Zynarator.Service;

namespace DotnetGenerator.Service.Facade;

public interface AchatItemService: IService<AchatItem, AchatItemCriteria>
{
    public Task<int> DeleteByAchatId(long id);
    public Task<int> DeleteByProduitId(long id);
    public Task<List<AchatItem>?> FindByAchatId(long id);
    public Task<List<AchatItem>?> FindByProduitId(long id);
}