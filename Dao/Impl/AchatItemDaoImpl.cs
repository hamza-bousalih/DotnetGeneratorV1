using System.Linq.Expressions;
using DotnetGenerator.Bean.Core;
using DotnetGenerator.Dao.Facade;
using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Repository;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerator.Dao.Impl;

public class AchatItemDaoImpl: Repository<AchatItem>, AchatItemDao
{
    public AchatItemDaoImpl(AppDbContext context) : base(context, context.AchatItems)
    {
    }

    protected override void SetContextEntry(AchatItem item)
    {
        SetEntry(item.Produit);
        SetEntry(item.Achat);
    }

    protected override IQueryable<AchatItem> SetIncluded()
    {
        return Table
            .Include(a => a.Produit)
            .Include(a => a.Achat);
    }

    public async Task<int> DeleteByAchatId(int id)=>
        await DeleteIf(item => item.Achat!.Id == id);

    public async Task<int> DeleteByProduitId(int id)=>
        await DeleteIf(item => item.Produit!.Id == id);

    public async Task<List<AchatItem>?> FindByAchatId(int id) => 
        await FindListIf(item => item.Achat!.Id == id);

    public async Task<List<AchatItem>?> FindByProduitId(int id) => 
        await FindListIf(item => item.Produit!.Id == id);
}