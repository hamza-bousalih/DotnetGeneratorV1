
using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Repository;
using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Dao.Repository.Facade;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerator.Dao.Impl;

public class RoleDaoImpl : Repository<Role>, RoleDao
{
    public async Task<Role?> FindByAuthority(String authority)
    {
        return await FindIf(el => el.Authority == authority);
    }

    public async Task<int> DeleteByAuthority(String authority)
    {
        return await DeleteIf(el => el.Authority == authority);
    }

    public new async Task<List<Role>> FindOptimized()
    {
        return await IncludedTable.Select(e => new Role { Id = e.Id, Authority = e.Authority }).ToListAsync();
    }

    public RoleDaoImpl(AppDbContext context) : base(context, context.Roles)
    {
    }
}