using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Dao.Criteria;
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
    public ModelPermissionUserServiceImpl(IContainer container) : base(container)
    {
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
}