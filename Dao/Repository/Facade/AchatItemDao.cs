using DotnetGenerator.Bean.Core;
using DotnetGenerator.Zynarator.Repository;

namespace DotnetGenerator.Dao.Facade;

public interface AchatItemDao: IRepository<AchatItem>
{
    public Task<int> DeleteByAchatId(long id);
    public Task<int> DeleteByProduitId(long id);
    public Task<List<AchatItem>?> FindByAchatId(long id);
    public Task<List<AchatItem>?> FindByProduitId(long id);
}