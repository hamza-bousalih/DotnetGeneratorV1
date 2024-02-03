using DotnetGenerator.Bean.Core;
using DotnetGenerator.Dao.Facade;
using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Repository;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerator.Dao.Repository.Impl;

public class AchatItemDaoImpl: Repository<AchatItem>, AchatItemDao
{
    public AchatItemDaoImpl(AppDbContext context) : base(context, context.AchatItems)
    {
    }

    protected override void SetContextEntry(AchatItem item)
    {
        SetUnchangedEntry(item.Produit);
        SetUnchangedEntry(item.Achat);
    }

    protected override IQueryable<AchatItem> SetIncluded()
    {
        return Table
            .Include(a => a.Produit)
            .Include(a => a.Achat);
    }

    protected override AchatItem Optimized(AchatItem e)
    {
        return new AchatItem
        {
            Id = e.Id
        };
    }

    public async Task<int> DeleteByAchatId(long id)=>
        await DeleteIf(item => item.Achat!.Id == id);

    public async Task<int> DeleteByProduitId(long id)=>
        await DeleteIf(item => item.Produit!.Id == id);

    public async Task<List<AchatItem>?> FindByAchatId(long id) => 
        await FindListIf(item => item.Achat!.Id == id);

    public async Task<List<AchatItem>?> FindByProduitId(long id) => 
        await FindListIf(item => item.Produit!.Id == id);
}