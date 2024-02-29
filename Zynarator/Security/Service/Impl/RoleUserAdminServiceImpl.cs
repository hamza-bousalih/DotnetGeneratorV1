using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Dao.Criteria;
using DotnetGenerator.Zynarator.Security.Dao.Repository;
using DotnetGenerator.Zynarator.Security.Dao.Repository.Facade;
using DotnetGenerator.Zynarator.Security.Dao.Specification;
using DotnetGenerator.Zynarator.Security.Service.Facade;
using DotnetGenerator.Zynarator.Service;
using Lamar;

namespace DotnetGenerator.Zynarator.Security.Service.Impl;

public class RoleUserServiceImpl : Service<RoleUser, RoleUserDao, RoleUserCriteria, RoleUserSpecification>,
    RoleUserService
{
    private readonly RoleService _roleService;

    public override async Task<RoleUser?> Create(RoleUser item, bool useTransaction = true)
    {
        return await Repository.TransactionBeginNullable(
            async () =>
            {
                if (item.Role is not null)
                {
                    var role = await _roleService.Create(item.Role, false);
                    item.Role = role;
                }

                if (item.Role != null) item.UserId = item.Role.Id;
                if (item.User != null) item.UserId = item.User.Id;
                return await base.Create(item, useTransaction);
            },
            useTransaction
        );
    }

    public RoleUserServiceImpl(IContainer container) : base(container)
    {
        _roleService = container.GetInstance<RoleService>();
    }

    public async Task<List<RoleUser>?> FindByUserId(long id)
    {
        return await Repository.FindByUserId(id);
    }

    public async Task<int> DeleteByUserId(long id)
    {
        return await Repository.DeleteByUserId(id);
    }

    public async Task<List<RoleUser>?> FindByRoleId(long id)
    {
        return await Repository.FindByRoleId(id);
    }

    public async Task<int> DeleteByRoleId(long id)
    {
        return await Repository.DeleteByRoleId(id);
    }

    public async Task<long> CountByRoleAuthority(string authority)
    {
        return await Repository.CountByRoleAuthority(authority);
    }

    public async Task<long> CountByUserEmail(string email)
    {
        return await Repository.CountByUserEmail(email);
    }
}