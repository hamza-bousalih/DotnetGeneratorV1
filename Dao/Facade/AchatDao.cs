using DotnetGenerator.Bean.Core;
using DotnetGenerator.Zynarator.Repository;

namespace DotnetGenerator.Dao.Facade;

public interface AchatDao: IRepository<Achat>
{
    public Task<int> DeleteByClientId(long id);
    public Task<List<Achat>?> FindByClientId(long id);
    public Task<Achat?> FindByReferenceEntity(string reference);
}