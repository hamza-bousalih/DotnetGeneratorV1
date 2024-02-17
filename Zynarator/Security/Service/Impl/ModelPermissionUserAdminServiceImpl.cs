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
}