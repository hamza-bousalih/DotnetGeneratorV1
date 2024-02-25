using DotnetGenerator.Zynarator.Repository;
using DotnetGenerator.Zynarator.Security.Bean;
using Microsoft.AspNetCore.Identity;

namespace DotnetGenerator.Zynarator.Security.Dao.Repository.Facade;

public interface UserDao : IRepository<User>, IUserStore<User>
{
    Task<User?> FindByUsername(string username);
    Task<int> DeleteByUsername(string username);
}