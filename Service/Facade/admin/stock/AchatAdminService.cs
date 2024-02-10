using DotnetGenerator.Bean.Core;
using DotnetGenerator.Zynarator.Service;
using DotnetGenerator.Dao.Criteria;

namespace DotnetGenerator.Service.Facade;

public interface AchatService: IService<Achat, AchatCriteria>{

    Task<List<Achat>?> FindByClientId(long id);

    Task<int> DeleteByClientId(long id);

}

