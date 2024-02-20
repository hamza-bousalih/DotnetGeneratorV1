using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Dao.Criteria;
using DotnetGenerator.Zynarator.Service;

namespace DotnetGenerator.Zynarator.Security.Service.Facade;

public interface RoleService : IService<Role, RoleCriteria>
{
    Task<Role?> FindByAuthority(string authority);
    Task<int> DeleteByAuthority(string authority);
}