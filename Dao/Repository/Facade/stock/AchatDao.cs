using DotnetGenerator.Bean.Core;
using DotnetGenerator.Zynarator.Repository;

namespace DotnetGenerator.Dao.Facade;

public interface AchatDao : IRepository<Achat> {

    Task<Achat?> FindByReference(String reference);
    Task<int>  DeleteByReference(String reference);

    Task<List<Achat>?> FindByClientId(long id);
    Task<int> DeleteByClientId(long id);



}
