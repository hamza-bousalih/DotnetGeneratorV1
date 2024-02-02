using DotnetGenerator.Bean.Core;
using DotnetGenerator.Dao.Criteria;
using Lamar;
using DotnetGenerator.Dao.Facade;
using DotnetGenerator.Dao.Repository.Impl;
using DotnetGenerator.Dao.Specification;
using DotnetGenerator.Data;
using DotnetGenerator.Service.Facade;
using DotnetGenerator.Service.Impl;
using DotnetGenerator.Zynarator.Specification;

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

    public static ServiceRegistry InjectSpecifications(this ServiceRegistry registry)
    {
        // Inject the repositories here
        registry.For<AchatSpecification>().Use<AchatSpecification>().Transient();
        registry.For<ClientSpecification>().Use<ClientSpecification>().Transient();
        registry.For<AchatItemSpecification>().Use<AchatItemSpecification>().Transient();
        registry.For<ProduitSpecification>().Use<ProduitSpecification>().Transient();

        return registry;
    }

    public static ServiceRegistry InjectLoader(this ServiceRegistry registry)
    {
        registry.For<DataLoader>().Use<DataLoader>().Scoped();

        return registry;
    }
}