using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Dao.Criteria;
using DotnetGenerator.Zynarator.Security.Dao.Repository.Facade;
using DotnetGenerator.Zynarator.Security.Dao.Specification;
using DotnetGenerator.Zynarator.Security.Service.Facade;
using DotnetGenerator.Zynarator.Service;
using Lamar;

namespace DotnetGenerator.Zynarator.Security.Service.Impl;

public class ActionPermissionServiceImpl :
    Service<ActionPermission, ActionPermissionDao, ActionPermissionCriteria, ActionPermissionSpecification>,
    ActionPermissionService
{
    public async Task<ActionPermission?> FindByReferenceEntity(ActionPermission t)
    {
        return await Repository.FindByReference(t.Reference!);
    }

    public async Task<int> DeleteByReferenceEntity(ActionPermission t)
    {
        return await Repository.DeleteByReference(t.Reference!);
    }


    public ActionPermissionServiceImpl(IContainer container) : base(container)
    {
    }
}