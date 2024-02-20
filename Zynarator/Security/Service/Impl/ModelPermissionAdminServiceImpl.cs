using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Dao.Criteria;
using DotnetGenerator.Zynarator.Security.Dao.Repository.Facade;
using DotnetGenerator.Zynarator.Security.Dao.Specification;
using DotnetGenerator.Zynarator.Security.Service.Facade;
using DotnetGenerator.Zynarator.Service;
using Lamar;

namespace DotnetGenerator.Zynarator.Security.Service.Impl;

public class ModelPermissionServiceImpl :
    Service<ModelPermission, ModelPermissionDao, ModelPermissionCriteria, ModelPermissionSpecification>,
    ModelPermissionService
{
    public new async Task<ModelPermission?> FindByReferenceEntity(ModelPermission t)
    {
        return await Repository.FindByReference(t.Reference!);
    }

    public async Task<int> DeleteByReferenceEntity(ModelPermission t)
    {
        return await Repository.DeleteByReference(t.Reference!);
    }

    public ModelPermissionServiceImpl(IContainer container) : base(container)
    {
    }
}