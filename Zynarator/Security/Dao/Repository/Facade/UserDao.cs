using DotnetGenerator.Zynarator.Repository;
using DotnetGenerator.Zynarator.Security.Bean;

namespace DotnetGenerator.Zynarator.Security.Dao.Repository.Facade;

public interface UserDao : IRepository<User>
{
    Task<User?> FindByUsername(String username);
    Task<int> DeleteByUsername(String username);
}