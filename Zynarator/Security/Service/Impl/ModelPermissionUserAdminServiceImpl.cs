using System.Collections;
using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Dao.Criteria;
using DotnetGenerator.Zynarator.Security.Dao.Repository;
using DotnetGenerator.Zynarator.Security.Dao.Repository.Facade;
using DotnetGenerator.Zynarator.Security.Dao.Specification;
using DotnetGenerator.Zynarator.Security.Service.Facade;
using DotnetGenerator.Zynarator.Service;
using Lamar;

namespace DotnetGenerator.Zynarator.Security.Service.Impl;

public class ModelPermissionUserServiceImpl :
    Service<ModelPermissionUser, ModelPermissionUserDao, ModelPermissionUserCriteria, ModelPermissionUserSpecification>,
    ModelPermissionUserService
{
    private readonly ModelPermissionService _modelPermissionService;
    private readonly ActionPermissionService _actionPermissionService;

    public ModelPermissionUserServiceImpl(IContainer container) : base(container)
    {
        _modelPermissionService = container.GetInstance<ModelPermissionService>();
        _actionPermissionService = container.GetInstance<ActionPermissionService>();
    }

    public override async Task<ModelPermissionUser?> Create(ModelPermissionUser item, bool useTransaction = true)
    {
        return await Repository.TransactionBegin(
            async () =>
            {
                var loaded = item.Id == 0 ? default : await FindByReferenceEntity(item);
                if (loaded != null) return loaded;

                if (item.ModelPermission != null) item.ModelPermission = await _modelPermissionService.Create(item.ModelPermission, false);
                if (item.ActionPermission != null) item.ActionPermission = await _actionPermissionService.Create(item.ActionPermission, false);

                return await Repository.Save(item);
            },
            useTransaction
        );
    }

    public async Task<List<ModelPermissionUser>?> FindByActionPermissionId(long id)
    {
        return await Repository.FindByActionPermissionId(id);
    }

    public async Task<int> DeleteByActionPermissionId(long id)
    {
        return await Repository.DeleteByActionPermissionId(id);
    }

    public async Task<List<ModelPermissionUser>?> FindByModelPermissionId(long id)
    {
        return await Repository.FindByModelPermissionId(id);
    }

    public async Task<int> DeleteByModelPermissionId(long id)
    {
        return await Repository.DeleteByModelPermissionId(id);
    }

    public async Task<List<ModelPermissionUser>?> FindByUserId(long id)
    {
        return await Repository.FindByUserId(id);
    }

    public async Task<int> DeleteByUserId(long id)
    {
        return await Repository.DeleteByUserId(id);
    }

    public async Task<List<ModelPermissionUser>> InitModelPermissionUser()
    {
        var modelPermissions = await _modelPermissionService.FindOptimized();
        var actionPermissions = await _actionPermissionService.FindOptimized();

        return modelPermissions
            .SelectMany(model =>
                actionPermissions.Select(action =>
                    new ModelPermissionUser
                    {
                        ModelPermission = model,
                        ActionPermission = action,
                        Value = true
                    }))
            .ToList();
    }


    public async Task<long> CountByActionPermissionReference(string reference)
    {
        return await Repository.CountByActionPermissionReference(reference);
    }

    public async Task<long> CountByModelPermissionReference(string reference)
    {
        return await Repository.CountByModelPermissionReference(reference);
    }

    public async Task<bool> FindByUserUsernameAndModelPermissionReferenceAndActionPermissionReference(string username,
        string modelReference,
        string actionReference)
    {
        var modelPermissionUser =
            await Repository.FindByUserUsernameAndModelReferenceAndActionReference(username, modelReference,
                actionReference);
        return modelPermissionUser?.Value ?? false;
    }

    public async Task<long>CountByUserEmail(string email)
    {
        return await Repository.CountByUserEmail(email);
    }
}