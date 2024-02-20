using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Repository;
using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Dao.Repository.Facade;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerator.Zynarator.Security.Dao.Repository.Impl;

public class RoleDaoImpl : Repository<Role>, RoleDao
{
    private readonly RoleManager<Role> _roleManager;
    
    public RoleDaoImpl(AppDbContext context, RoleManager<Role> roleManager) : base(context, context.Roles)
    {
        _roleManager = roleManager;
    }

    public async Task<Role?> FindByAuthority(string authority)
    {
        return await Table.FirstOrDefaultAsync(r => r.Authority == authority);
    }

    public async Task<int> DeleteByAuthority(string authority)
    {
        return await Table.Where(r => r.Authority == authority).ExecuteDeleteAsync();
    }
}