using DotnetGenerator.Bean.Core;
using DotnetGenerator.Dao.Facade;
using DotnetGenerator.Service.Facade;
using DotnetGenerator.Zynarator.Service;
using DotnetGenerator.Dao.Criteria;
using DotnetGenerator.Dao.Specification;
using Lamar;

namespace DotnetGenerator.Service.Impl;


public class ClientServiceImpl: Service<Client, ClientDao, ClientCriteria, ClientSpecification>, ClientService{



    public async Task<Client?> FindByReferenceEntity(Client t){
        return await Repository.FindByCin(t.Cin!);
    }
    public async Task<int> DeleteByReferenceEntity(Client t){
        return await Repository.DeleteByCin(t.Cin!);
    }


    public ClientServiceImpl(IContainer container) : base(container){
    }

}

