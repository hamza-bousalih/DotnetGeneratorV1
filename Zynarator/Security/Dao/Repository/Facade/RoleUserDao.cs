using DotnetGenerator.Zynarator.Repository;
using DotnetGenerator.Zynarator.Security.Bean;

namespace DotnetGenerator.Zynarator.Security.Dao.Repository.Facade;

public interface RoleUserDao : IRepository<RoleUser>
{
    Task<List<RoleUser>?> FindByUserId(long id);
    Task<int> DeleteByUserId(long id);
    Task<List<RoleUser>?> FindByRoleId(long id);
    Task<int> DeleteByRoleId(long id);
    Task<long> CountByRoleAuthority(string authority);
    Task<long> CountByUserEmail(string email);
}