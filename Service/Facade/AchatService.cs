using DotnetGenerator.Bean.Core;
using DotnetGenerator.Zynarator.Service;

namespace DotnetGenerator.Service.Facade;

public interface AchatService: IService<Achat>
{
    public Task<int> DeleteByClientId(int id);
    public Task<List<Achat>?> FindByClientId(int id);
}