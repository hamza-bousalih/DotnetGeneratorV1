using DotnetGenerator.Bean.Core;
using DotnetGenerator.Zynarator.Repository;

namespace DotnetGenerator.Dao.Facade;

public interface AchatDao: IRepository<Achat>
{
    public Task<int> DeleteByClientId(int id);
}