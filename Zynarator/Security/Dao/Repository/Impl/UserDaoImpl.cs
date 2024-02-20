using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Repository;
using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Dao.Repository.Facade;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerator.Zynarator.Security.Dao.Repository.Impl;

public class UserDaoImpl : Repository<User>, UserDao
{
    private readonly UserManager<User> _userManager;
    
    public UserDaoImpl(AppDbContext context, UserManager<User> userManager) : base(context, context.Users)
    {
        _userManager = userManager;
    }

    protected override IQueryable<User> SetIncluded()
    {
        return Table
            .Include(u => u.ModelPermissionUsers)!
            .ThenInclude(mp => mp.ModelPermission)
            .Include(u => u.ModelPermissionUsers)!
            .ThenInclude(mp => mp.ActionPermission)
            .Include(u => u.RoleUsers)!
            .ThenInclude(ru => ru.Role);
    }

    public new async Task<User> Save(User user)
    {
        var usernameToken = (user.UserName is not null && await FindByUsername(user.UserName) != null)
                            && (user.Email is not null && await FindByEmail(user.Email) != null);
        if (usernameToken) return null!;

        user.AccountNonExpired = true;
        user.AccountNonLocked = true;
        user.CredentialsNonExpired = true;
        user.Enabled = true;
        user.PasswordChanged = false;
        user.createdAt = DateTime.Now;

        var createResult = await _userManager.CreateAsync(user, user.Password ?? user.UserName!);

        //TODO: create associated lists

        return user;
    }

    public async Task<bool> ChangePassword(User user, string currentPassword, string newPassword)
    {
        var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        return result.Succeeded;
    }

    public async Task<bool> CheckPassword(User user, string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }

    public async Task<User?> FindByUsername(string username) => await FindIf(u => u.UserName == username);
    public async Task<User?> FindByEmail(string email) => await FindIf(u => u.Email == email);
    public async Task<int> DeleteByUsername(string username) => await DeleteIf(u => u.UserName == username);
}