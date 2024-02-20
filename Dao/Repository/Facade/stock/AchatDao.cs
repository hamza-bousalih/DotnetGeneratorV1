using DotnetGenerator.Bean.Core;
using DotnetGenerator.Zynarator.Repository;

namespace DotnetGenerator.Dao.Facade;

public interface AchatDao : IRepository<Achat>
{
    Task<Achat?> FindByReference(string reference);
    Task<int> DeleteByReference(string reference);

    Task<List<Achat>?> FindByClientId(long id);
    Task<int> DeleteByClientId(long id);
}