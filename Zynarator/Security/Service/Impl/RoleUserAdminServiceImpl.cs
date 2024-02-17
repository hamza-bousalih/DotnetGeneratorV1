using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Dao.Criteria;
using DotnetGenerator.Zynarator.Security.Dao.Repository.Facade;
using DotnetGenerator.Zynarator.Security.Dao.Specification;
using DotnetGenerator.Zynarator.Security.Service.Facade;
using DotnetGenerator.Zynarator.Service;
using Lamar;

namespace DotnetGenerator.Zynarator.Security.Service.Impl;

public class RoleUserServiceImpl : Service<RoleUser, RoleUserDao, RoleUserCriteria, RoleUserSpecification>,
    RoleUserService
{
    public RoleUserServiceImpl(IContainer container) : base(container)
    {
    }
}