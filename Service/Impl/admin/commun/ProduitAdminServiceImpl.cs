using DotnetGenerator.Bean.Core;
using DotnetGenerator.Dao.Facade;
using DotnetGenerator.Service.Facade;
using DotnetGenerator.Zynarator.Service;
using DotnetGenerator.Dao.Criteria;
using DotnetGenerator.Dao.Specification;
using Lamar;

namespace DotnetGenerator.Service.Impl;

public class ProduitServiceImpl : Service<Produit, ProduitDao, ProduitCriteria, ProduitSpecification>, ProduitService
{
    public new async Task<Produit?> FindByReferenceEntity(Produit t)
    {
        return await Repository.FindByReference(t.Reference!);
    }

    public async Task<int> DeleteByReferenceEntity(Produit t)
    {
        return await Repository.DeleteByReference(t.Reference!);
    }


    public ProduitServiceImpl(IContainer container) : base(container)
    {
    }
}