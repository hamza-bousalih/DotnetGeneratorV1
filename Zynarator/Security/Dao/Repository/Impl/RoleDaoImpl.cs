using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Security.Bean;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerator.Zynarator.Security.Dao.Repository.Impl;

public class RoleDaoImpl : RoleStore<Role, AppDbContext, long, RoleUser, IdentityRoleClaim<long>>, Facade.RoleDao
{
    public RoleDaoImpl(AppDbContext context, IdentityErrorDescriber? describer = null) : base(context, describer)
    {
    }

    public async Task<Role?> FindById(long id) => await FindByIdAsync(id.ToString());

    public async Task<List<Role>> FindAll() => await Roles.ToListAsync();

    public async Task<List<Role>> FindOptimized() => await FindAll();

    public async Task<Role> Save(Role role)
    {
        await CreateAsync(role);
        return role;
    }

    public async Task<List<Role>> Save(List<Role> roles)
    {
        var result = new List<Role>();
        foreach (var role in roles)
        {
            var saved = await Save(role);
            result.Add(saved);
        }

        return result;
    }

    public async Task<Role> Update(Role role)
    {
        await UpdateAsync(role);
        return role;
    }

    public async Task<List<Role>> Update(List<Role> roles)
    {
        var result = new List<Role>();
        foreach (var role in roles)
        {
            var saved = await Update(role);
            result.Add(saved);
        }

        return result;
    }

    public async Task<int> Delete(Role role)
    {
        var result = await DeleteAsync(role);
        return result.Succeeded ? 1 : 0;
    }

    public async Task<int> Delete(List<Role> roles)
    {
        var result = 0;
        foreach (var role in roles) result += await Delete(role);
        return result;
    }

    public async Task<int> DeleteById(long id)
    {
        var found = await FindById(id);
        return (found == null) ? 0 : await Delete(found);
    }

    public async Task<int> Count()
    {
        return await Roles.CountAsync();
    }

    public async Task<Role?> FindByAuthority(string authority)
    {
        return await Roles.FirstOrDefaultAsync(it => it.Authority == authority);
    }

    public async Task<int> DeleteByAuthority(string authority)
    {
        return await Roles.Where(it => it.Authority == authority).ExecuteDeleteAsync();
    }
}