using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Dao.Criteria;
using DotnetGenerator.Zynarator.Security.Dao.Repository.Facade;
using DotnetGenerator.Zynarator.Security.Dao.Specification;
using DotnetGenerator.Zynarator.Security.Service.Facade;
using DotnetGenerator.Zynarator.Service;
using Lamar;

namespace DotnetGenerator.Zynarator.Security.Service.Impl;

public class RoleServiceImpl : Service<Role, RoleDao, RoleCriteria, RoleSpecification>, RoleService
{
    public async Task<Role?> FindByReferenceEntity(Role t)
    {
        return await Repository.FindByAuthority(t.Authority!);
    }

    public async Task<int> DeleteByReferenceEntity(Role t)
    {
        return await Repository.DeleteByAuthority(t.Authority!);
    }


    public RoleServiceImpl(IContainer container) : base(container)
    {
    }
}