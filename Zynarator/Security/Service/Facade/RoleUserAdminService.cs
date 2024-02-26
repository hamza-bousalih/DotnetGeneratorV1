using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Dao.Criteria;
using DotnetGenerator.Zynarator.Service;

namespace DotnetGenerator.Zynarator.Security.Service.Facade;

public interface RoleUserService : IService<RoleUser, RoleUserCriteria>
{
    Task<List<RoleUser>?> FindByUserId(long id);
    Task<int> DeleteByUserId(long id);
    Task<List<RoleUser>?> FindByRoleId(long id);
    Task<int> DeleteByRoleId(long id);

    Task<long> CountByRoleAuthority(string authority);
    Task<long> CountByUserEmail(string email);
}