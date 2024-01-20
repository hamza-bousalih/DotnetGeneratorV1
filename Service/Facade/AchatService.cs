using DotnetGenerator.Bean.Core;
using DotnetGenerator.Zynarator.Service;

namespace DotnetGenerator.Service.Facade;

public interface AchatService: IService<Achat>
{
    public Task<int> DeleteByClientId(long id);
    public Task<List<Achat>?> FindByClientId(long id);
}