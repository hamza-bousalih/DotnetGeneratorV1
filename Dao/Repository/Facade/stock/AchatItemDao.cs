using DotnetGenerator.Bean.Core;
using DotnetGenerator.Zynarator.Repository;

namespace DotnetGenerator.Dao.Facade;

public interface AchatItemDao : IRepository<AchatItem>
{
    Task<List<AchatItem>?> FindByProduitId(long id);
    Task<int> DeleteByProduitId(long id);
    Task<List<AchatItem>?> FindByAchatId(long id);
    Task<int> DeleteByAchatId(long id);
}