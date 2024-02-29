using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Dao.Criteria;
using DotnetGenerator.Zynarator.Security.Dao.Repository;
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

    public override async Task<User?> Create(User item, bool useTransaction = true)
    {
        return await Repository.TransactionBeginNullable(
            async () =>
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
                
                var foundedUserByUsername = await FindByUsername(item.UserName);
                var foundedUserByEmail = await FindByEmail(item.Email);
                if (foundedUserByUsername is not null|| foundedUserByEmail is not null) return null;
                
                await _userManager.CreateAsync(item, item.Password);
                if (roleUsers != null)
                {
                    foreach (var element in roleUsers)
                    {
                        element.User = item;
                        await _roleUserService.Create(element, false);
                        item.RoleUsers!.Add(element);
                    }
                }

                if (modelPermissionUsers == null) return item;
                {
                    foreach (var element in modelPermissionUsers)
                    {
                        element.User = item;
                        await _modelPermissionUserService.Create(element, false);
                        item.ModelPermissionUsers!.Add(element);
                    }
                }

                return item;
            },
            useTransaction
        );
    }

    public new async Task<User?> FindByReferenceEntity(User t)
    {
        return await Repository.FindByUsername(t.UserName!);
    }

    public async Task<int> DeleteByReferenceEntity(User t)
    {
        return await Repository.DeleteByUsername(t.UserName!);
    }

    public async Task<User?> FindByUsername(string? username)
    {
        if (username is null) return null;
        return await Repository.FindByUsername(username);
    }

    public async Task<User?> FindByEmail(string? email)
    {
        if (email is null) return null;
        return await Repository.FindByUsername(email);
    }

    public async Task<int> DeleteByUsername(string username)
    {
        return await Repository.DeleteByUsername(username);
    }

    public async Task<bool> ChangePassword(string username, string password)
    {
        return await Repository.TransactionBegin(
            async () =>
            {
                var user = await Repository.FindByUsername(username);
                if (user == null) return false;
                user.PasswordChanged = true;
                var result = await _userManager.ChangePasswordAsync(user, user.Password, password);
                return result.Succeeded;
            }
        );
    }

    public async Task<bool> CheckPassword(User user, string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }

    public override async Task<User?> FindWithAssociatedLists(long id)
    {
        var result = await Repository.FindById(id);
        if (result == null || result.Id == 0) return result;
        result.ModelPermissionUsers = await _modelPermissionUserService.FindByUserId(id);
        result.RoleUsers = await _roleUserService.FindByUserId(id);
        return result;
    }

    protected override async Task DeleteAssociatedLists(long id)
    {
        await _modelPermissionUserService.DeleteByUserId(id);
        await _roleUserService.DeleteByUserId(id);
    }

    protected override async Task UpdateWithAssociatedLists(User? user)
    {
        if (user != null && user.Id != 0)
        {
            var resultModelPermissionUsers =
                _modelPermissionUserService.GetToBeSavedAndToBeDeleted(
                    await _modelPermissionUserService.FindByUserId(user.Id), user.ModelPermissionUsers);
            await _modelPermissionUserService.Delete(resultModelPermissionUsers[1]);
            resultModelPermissionUsers[0].ForEach(e => e.User = user);
            await _modelPermissionUserService.Update(resultModelPermissionUsers[0]);

            var resultRoleUsers =
                _roleUserService.GetToBeSavedAndToBeDeleted(await _roleUserService.FindByUserId(user.Id),
                    user.RoleUsers);
            await _roleUserService.Delete(resultRoleUsers[1]);
            resultRoleUsers[0].ForEach(e => e.User = user);
            await _roleUserService.Update(resultRoleUsers[0]);
        }
    }

    public async Task<User?> FindByUsernameWithRoles(string username)
    {
        return await Repository.FindByUsername(username);
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