using DotnetGenerator.Zynarator.Repository;
using DotnetGenerator.Zynarator.Security.Bean;

namespace DotnetGenerator.Zynarator.Security.Dao.Repository.Facade;

public interface UserDao : IRepository<User>
{
    Task<User?> FindByUsername(string username);
    Task<int> DeleteByUsername(string username);
    Task<bool> ChangePassword(User user, string currentPassword, string newPassword);
    Task<bool> CheckPassword(User user, string password);
}