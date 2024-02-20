using DotnetGenerator.Bean.Core;
using DotnetGenerator.Zynarator.Service;
using DotnetGenerator.Dao.Criteria;

namespace DotnetGenerator.Service.Facade;

public interface AchatItemService : IService<AchatItem, AchatItemCriteria>
{
    Task<List<AchatItem>?> FindByAchatId(long id);

    Task<int> DeleteByAchatId(long id);
}