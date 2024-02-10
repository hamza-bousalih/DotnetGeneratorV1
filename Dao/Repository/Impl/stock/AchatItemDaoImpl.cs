using DotnetGenerator.Bean.Core;
using DotnetGenerator.Dao.Facade;
using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Repository;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerator.Dao.Impl;

public class AchatItemDaoImpl : Repository<AchatItem>, AchatItemDao {



    public async Task<List<AchatItem>?> FindByProduitId(long id) {
        return await FindListIf(item => item.Produit!.Id == id);
    }
    public async Task<int> DeleteByProduitId(long id) {
        return await DeleteIf(item => item.Produit!.Id == id);
    }
    public async Task<List<AchatItem>?> FindByAchatId(long id) {
        return await FindListIf(item => item.Achat!.Id == id);
    }
    public async Task<int> DeleteByAchatId(long id) {
        return await DeleteIf(item => item.Achat!.Id == id);
    }


    public AchatItemDaoImpl(AppDbContext context) : base(context, context.AchatItems){
    }

}
