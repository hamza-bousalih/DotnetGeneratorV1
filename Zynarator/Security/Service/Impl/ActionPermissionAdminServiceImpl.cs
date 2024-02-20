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
    public ActionPermissionServiceImpl(IContainer container) : base(container)
    {
    }

    public async Task<ActionPermission?> FindByReference(string reference)
    {
        return await Repository.FindByReference(reference);
    }

    public async Task<int> DeleteByReference(string reference)
    {
        return await Repository.DeleteByReference(reference);
    }
}