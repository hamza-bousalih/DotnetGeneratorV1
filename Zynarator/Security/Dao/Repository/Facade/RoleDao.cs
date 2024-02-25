using DotnetGenerator.Zynarator.Repository;
using DotnetGenerator.Zynarator.Security.Bean;
using Microsoft.AspNetCore.Identity;

namespace DotnetGenerator.Zynarator.Security.Dao.Repository.Facade;

public interface RoleDao : IRepository<Role>, IRoleStore<Role>
{
    Task<Role?> FindByAuthority(string authority);
    Task<int> DeleteByAuthority(string authority);
}