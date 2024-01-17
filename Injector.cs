using Lamar;
using DotnetGenerator.Dao.Facade;
using DotnetGenerator.Dao.Impl;
using DotnetGenerator.Service.Facade;
using DotnetGenerator.Service.Impl;

namespace DotnetGenerator;

public static class Injector
{
    public static ServiceRegistry InjectServices(this ServiceRegistry registry)
    {
        // Inject the service here
        registry.For<AchatService>().Use<AchatServiceImpl>().Scoped();
        registry.For<AchatItemService>().Use<AchatItemServiceImpl>().Scoped();

        return registry;
    }

    public static ServiceRegistry InjectRepositories(this ServiceRegistry registry)
    {
        // Inject the repositories here
        registry.For<AchatDao>().Use<AchatDaoImpl>().Transient();
        registry.For<AchatItemDao>().Use<AchatItemDaoImpl>().Transient();

        return registry;
    }
}