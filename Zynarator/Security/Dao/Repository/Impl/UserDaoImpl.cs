using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Dao.Repository.Facade;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerator.Zynarator.Security.Dao.Repository.Impl;

public class UserDaoImpl : UserStore<User, Role, AppDbContext, long, IdentityUserClaim<long>, RoleUser,
    IdentityUserLogin<long>, IdentityUserToken<long>, IdentityRoleClaim<long>>, UserDao
{
    public UserDaoImpl(AppDbContext context, IdentityErrorDescriber? describer = null) : base(context, describer)
    {
    }

    public async Task<User?> FindById(long id)
    {
        return await Users
            .Include(u => u.RoleUsers)!
            .ThenInclude(ur => ur.Role)
            .Include(u => u.ModelPermissionUsers)!
            .ThenInclude(mp => mp.ActionPermission)
            .Include(u => u.ModelPermissionUsers)!
            .ThenInclude(mp => mp.ModelPermission)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<List<User>> FindAll()
    {
        return await Users.ToListAsync();
    }

    public async Task<List<User>> FindOptimized()
    {
        return await Users.Select(u => new User { Id = u.Id, UserName = u.UserName }).ToListAsync();
    }

    public async Task<User> Save(User user)
    {
        user.AccountNonExpired = true;
        user.AccountNonLocked = true;
        user.CredentialsNonExpired = true;
        user.Enabled = true;
        user.PasswordChanged = false;
        user.createdAt = DateTime.Now;
        await CreateAsync(user);
        return user;
    }

    public async Task<List<User>> Save(List<User> users)
    {
        var result = new List<User>();
        foreach (var user in users)
        {
            var save = await Save(user);
            result.Add(save);
        }

        return result;
    }

    public async Task<User> Update(User user)
    {
        await UpdateAsync(user);
        return user;
    }

    public async Task<List<User>> Update(List<User> users)
    {
        var result = new List<User>();
        foreach (var user in users)
        {
            var save = await Update(user);
            result.Add(save);
        }

        return result;
    }

    public async Task<int> Delete(User user)
    {
        var result = await DeleteAsync(user);
        return result.Succeeded ? 1 : 0;
    }

    public async Task<int> Delete(List<User> users)
    {
        var result = 0;
        foreach (var user in users) result += await Delete(user);
        return result;
    }

    public async Task<int> DeleteById(long id)
    {
        var found = await FindById(id);
        return found == null ? 0 : await Delete(found);
    }

    public async Task<int> Count()
    {
        return await Users.CountAsync();
    }

    public async Task<User?> FindByUsername(string username)
    {
        return await FindByNameAsync(username);
    }

    public async Task<int> DeleteByUsername(string username)
    {
        return await Users.Where(u => u.UserName == username).ExecuteDeleteAsync();
    }

    public async Task<User?> FindByNameAsync(string normalizedUserName)
    {
        return await Users
            .Include(u => u.RoleUsers)!
            .ThenInclude(ur => ur.Role)
            .Include(u => u.ModelPermissionUsers)!
            .ThenInclude(mp => mp.ActionPermission)
            .Include(u => u.ModelPermissionUsers)!
            .ThenInclude(mp => mp.ModelPermission)
            .FirstOrDefaultAsync(u => u.NormalizedUserName == normalizedUserName);
    }
}