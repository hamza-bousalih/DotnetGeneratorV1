using DotnetGenerator.Bean.Core;
using DotnetGenerator.Dao.Facade;
using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Repository;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerator.Dao.Impl;

public class ProduitDaoImpl : Repository<Produit>, ProduitDao {

    public async Task<Produit?> FindByReference(String reference){
        return await FindIf(el => el.Reference == reference);
    }

    public async Task<int>  DeleteByReference(String reference){
        return await DeleteIf(el => el.Reference == reference);
    }

    public new async Task<List<Produit>> FindOptimized() {
        return await IncludedTable.Select(e => new Produit{Id = e.Id, Reference = e.Reference}).ToListAsync();
    }



    public ProduitDaoImpl(AppDbContext context) : base(context, context.Produits){
    }

}
