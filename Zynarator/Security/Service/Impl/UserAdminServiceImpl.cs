using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Dao.Criteria;
using DotnetGenerator.Zynarator.Security.Dao.Repository.Facade;
using DotnetGenerator.Zynarator.Security.Dao.Specification;
using DotnetGenerator.Zynarator.Security.Service.Facade;
using DotnetGenerator.Zynarator.Service;
using Lamar;
using Microsoft.AspNetCore.Identity;

namespace DotnetGenerator.Zynarator.Security.Service.Impl;

public class UserServiceImpl : Service<User, UserDao, UserCriteria, UserSpecification>, UserService
{
    private readonly UserManager<User> _userManager;

    public override async Task<User> Create(User item)
    {
        RoleUser[]? roleUsers = null;
        if (item.RoleUsers != null)
        {
            roleUsers = new RoleUser[item.RoleUsers!.Count];
            item.RoleUsers.CopyTo(roleUsers);
            item.RoleUsers.Clear();
        }

        ModelPermissionUser[]? modelPermissionUsers = null;
        if (item.ModelPermissionUsers != null)
        {
            modelPermissionUsers = new ModelPermissionUser[item.ModelPermissionUsers!.Count];
            item.ModelPermissionUsers.CopyTo(modelPermissionUsers);
            item.ModelPermissionUsers.Clear();
        }
        
        await _userManager.CreateAsync(item, item.Password);
        if (roleUsers != null)
        {
            foreach (var element in roleUsers)
            {
                element.User = item;
                await _roleUserService.Create(element);
                item.RoleUsers!.Add(element);
            }
        }

        if (modelPermissionUsers == null) return item;
        {
            foreach (var element in modelPermissionUsers)
            {
                element.User = item;
                await _modelPermissionUserService.Create(element);
                item.ModelPermissionUsers!.Add(element);
            }
        }

        return item;
    }

    public new async Task<User?> FindByReferenceEntity(User t)
    {
        return await Repository.FindByUsername(t.UserName!);
    }

    public async Task<int> DeleteByReferenceEntity(User t)
    {
        return await Repository.DeleteByUsername(t.UserName!);
    }

    public async Task<User?> FindByUsername(string username)
    {
        return await Repository.FindByUsername(username);
    }

    public async Task<int> DeleteByUsername(string username)
    {
        return await Repository.DeleteByUsername(username);
    }

    public async Task<bool> ChangePassword(string username, string password)
    {
        var user = await Repository.FindByUsername(username);
        if (user == null) return false;
        user.PasswordChanged = true;
        var result = await _userManager.ChangePasswordAsync(user, user.Password, password);
        return result.Succeeded;
    }

    public async Task<bool> CheckPassword(User user, string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }

    public UserServiceImpl(IContainer container, UserManager<User> userManager) : base(container)
    {
        _userManager = userManager;
        _modelPermissionUserService = container.GetInstance<ModelPermissionUserService>();
        _roleUserService = container.GetInstance<RoleUserService>();
    }

    private readonly ModelPermissionUserService _modelPermissionUserService;
    private readonly RoleUserService _roleUserService;
}