using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Dao.Criteria;
using DotnetGenerator.Zynarator.Service;

namespace DotnetGenerator.Zynarator.Security.Service.Facade;

public interface UserService : IService<User, UserCriteria>
{
    Task<User?> FindByUsername(string username);
    Task<int> DeleteByUsername(string username);
    Task<bool> ChangePassword(string username, string password);
    Task<bool> CheckPassword(User user, string password);
}