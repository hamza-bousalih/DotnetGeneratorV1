using Lamar;
using DotnetGenerator.Dao.Facade;
using DotnetGenerator.Dao.Impl;
using DotnetGenerator.Service.Facade;
using DotnetGenerator.Service.Impl;
using DotnetGenerator.Dao.Specification;

namespace DotnetGenerator;

public static class Injector
{

    public static void Inject(this ServiceRegistry registry)
    {
        registry.InjectRepositories().InjectSpecifications().InjectServices();
    }

    public static ServiceRegistry InjectServices(this ServiceRegistry registry)
    {
        // Inject the service here
                registry.For<ClientService>().Use<ClientServiceImpl>().Scoped();
        registry.For<AchatService>().Use<AchatServiceImpl>().Scoped();
        registry.For<AchatItemService>().Use<AchatItemServiceImpl>().Scoped();
        registry.For<ProduitService>().Use<ProduitServiceImpl>().Scoped();
        return registry;
    }

    public static ServiceRegistry InjectRepositories(this ServiceRegistry registry)
    {
        // Inject the repositories here
        registry.For<ClientDao>().Use<ClientDaoImpl>().Transient();
        registry.For<AchatDao>().Use<AchatDaoImpl>().Transient();
        registry.For<AchatItemDao>().Use<AchatItemDaoImpl>().Transient();
        registry.For<ProduitDao>().Use<ProduitDaoImpl>().Transient();
        return registry;
    }

    public static ServiceRegistry InjectSpecifications(this ServiceRegistry registry)
    {
        // Inject the specifications here
        registry.For<ClientSpecification>().Use<ClientSpecification>().Transient();
        registry.For<AchatSpecification>().Use<AchatSpecification>().Transient();
        registry.For<AchatItemSpecification>().Use<AchatItemSpecification>().Transient();
        registry.For<ProduitSpecification>().Use<ProduitSpecification>().Transient();
        return registry;
    }
}
