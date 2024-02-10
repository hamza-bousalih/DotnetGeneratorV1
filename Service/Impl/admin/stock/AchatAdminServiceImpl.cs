﻿using DotnetGenerator.Bean.Core;
using DotnetGenerator.Dao.Facade;
using DotnetGenerator.Service.Facade;
using DotnetGenerator.Zynarator.Service;
using DotnetGenerator.Dao.Criteria;
using DotnetGenerator.Dao.Specification;
using Lamar;

namespace DotnetGenerator.Service.Impl;


public class AchatServiceImpl: Service<Achat, AchatDao, AchatCriteria, AchatSpecification>, AchatService{

    public async Task<List<Achat>?> FindByClientId(long id) => await Repository.FindByClientId(id);
    public async Task<int> DeleteByClientId(long id) => await Repository.DeleteByClientId(id);


    public async Task<Achat?> FindByReferenceEntity(Achat t){
        return await Repository.FindByReference(t.Reference!);
    }
    public async Task<int> DeleteByReferenceEntity(Achat t){
        return await Repository.DeleteByReference(t.Reference!);
    }


    public AchatServiceImpl(IContainer container) : base(container){
    }

}

