using DotnetGenerator.Zynarator.Security.Dao.Repository.Facade;
using DotnetGenerator.Zynarator.Security.Dao.Repository.Impl;
using DotnetGenerator.Zynarator.Security.Dao.Specification;
using DotnetGenerator.Zynarator.Security.Service.Facade;
using DotnetGenerator.Zynarator.Security.Service.Impl;
using Lamar;

namespace DotnetGenerator.Zynarator.Security;

public static class SecurityInjector
{
    public static void InjectForSecurity(this ServiceRegistry registry)
    {
        registry.InjectRepositories().InjectSpecifications().InjectServices();
    }

    public static ServiceRegistry InjectServices(this ServiceRegistry registry)
    {
        // Inject the service here
        registry.For<RoleUserService>().Use<RoleUserServiceImpl>().Scoped();
        registry.For<RoleService>().Use<RoleServiceImpl>().Scoped();
        registry.For<ModelPermissionUserService>().Use<ModelPermissionUserServiceImpl>().Scoped();
        registry.For<ActionPermissionService>().Use<ActionPermissionServiceImpl>().Scoped();
        registry.For<ModelPermissionService>().Use<ModelPermissionServiceImpl>().Scoped();
        registry.For<UserService>().Use<UserServiceImpl>().Scoped();
        return registry;
    }

    public static ServiceRegistry InjectRepositories(this ServiceRegistry registry)
    {
        // Inject the repositories here
        registry.For<RoleUserDao>().Use<RoleUserDaoImpl>().Scoped();
        registry.For<RoleDao>().Use<RoleDaoImpl>().Scoped();
        registry.For<ModelPermissionUserDao>().Use<ModelPermissionUserDaoImpl>().Scoped();
        registry.For<ActionPermissionDao>().Use<ActionPermissionDaoImpl>().Scoped();
        registry.For<ModelPermissionDao>().Use<ModelPermissionDaoImpl>().Scoped();
        registry.For<UserDao>().Use<UserDaoImpl>().Scoped();
        return registry;
    }

    public static ServiceRegistry InjectSpecifications(this ServiceRegistry registry)
    {
        // Inject the specifications here
        registry.For<RoleUserSpecification>().Use<RoleUserSpecification>().Scoped();
        registry.For<RoleSpecification>().Use<RoleSpecification>().Scoped();
        registry.For<ModelPermissionUserSpecification>().Use<ModelPermissionUserSpecification>().Scoped();
        registry.For<ActionPermissionSpecification>().Use<ActionPermissionSpecification>().Scoped();
        registry.For<ModelPermissionSpecification>().Use<ModelPermissionSpecification>().Scoped();
        registry.For<UserSpecification>().Use<UserSpecification>().Scoped();
        return registry;
    }
}