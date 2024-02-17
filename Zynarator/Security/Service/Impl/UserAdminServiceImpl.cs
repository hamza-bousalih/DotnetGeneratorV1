using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Dao.Criteria;
using DotnetGenerator.Zynarator.Security.Dao.Repository.Facade;
using DotnetGenerator.Zynarator.Security.Dao.Specification;
using DotnetGenerator.Zynarator.Security.Service.Facade;
using DotnetGenerator.Zynarator.Service;
using Lamar;

namespace DotnetGenerator.Zynarator.Security.Service.Impl;

public class UserServiceImpl : Service<User, UserDao, UserCriteria, UserSpecification>, UserService
{
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

        await base.Create(item);
        if (roleUsers != null)
        {
            foreach (var element in roleUsers)
            {
                element.User = item;
                await _roleUserService.Create(element);
                item.RoleUsers!.Add(element);
            }
        }

        if (modelPermissionUsers != null)
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


    public async Task<User?> FindByReferenceEntity(User t)
    {
        return await Repository.FindByUsername(t.Username!);
    }

    public async Task<int> DeleteByReferenceEntity(User t)
    {
        return await Repository.DeleteByUsername(t.Username!);
    }


    public UserServiceImpl(IContainer container) : base(container)
    {
        _modelPermissionUserService = container.GetInstance<ModelPermissionUserService>();
        _roleUserService = container.GetInstance<RoleUserService>();
    }

    private ModelPermissionUserService _modelPermissionUserService;
    private RoleUserService _roleUserService;
}