using DotnetGenerator.Bean.Core;
using DotnetGenerator.Zynarator.Repository;

namespace DotnetGenerator.Dao.Facade;

public interface AchatItemDao: IRepository<AchatItem>
{
    public Task<int> DeleteByAchatId(int id);
    public Task<int> DeleteByProduitId(int id);
}