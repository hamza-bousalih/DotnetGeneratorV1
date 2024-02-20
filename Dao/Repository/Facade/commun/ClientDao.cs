using DotnetGenerator.Bean.Core;
using DotnetGenerator.Zynarator.Repository;

namespace DotnetGenerator.Dao.Facade;

public interface ClientDao : IRepository<Client>
{
    Task<Client?> FindByCin(string cin);
    Task<int> DeleteByCin(string cin);
}