using DotnetGenerator.Zynarator.Repository;
using DotnetGenerator.Zynarator.Security.Bean;

namespace DotnetGenerator.Zynarator.Security.Dao.Repository.Facade;

public interface RoleDao : IRepository<Role>
{
    Task<Role?> FindByAuthority(String authority);
    Task<int> DeleteByAuthority(String authority);
}