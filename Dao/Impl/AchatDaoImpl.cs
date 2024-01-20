using DotnetGenerator.Bean.Core;
using DotnetGenerator.Dao.Facade;
using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Repository;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerator.Dao.Impl;

public class AchatDaoImpl: Repository<Achat>, AchatDao
{
    public AchatDaoImpl(AppDbContext context) : base(context, context.Achats)
    {
    }

    protected override void SetContextEntry(Achat item)
    {
        SetEntry(item.AchatItems);
        SetEntry(item.Client);
    }

    protected override IQueryable<Achat> SetIncluded()
    {
        return Table
            .Include(a => a.AchatItems)
            .Include(a => a.Client);
    }

    public async Task<int> DeleteByClientId(int id) =>
        await DeleteIf(item => item.Client !=null && item.Client.Id == id);

    public async Task<List<Achat>?> FindByClientId(int id)
    {
        return await FindListIf(item => item.Client != null && item.Client.Id == id);
    }

    public async Task<Achat?> FindByReferenceEntity(string reference) => 
        await FindIf(el => el.Reference == reference);
}