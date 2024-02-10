using DotnetGenerator.Bean.Core;
using DotnetGenerator.Dao.Facade;
using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Repository;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerator.Dao.Impl;

public class AchatDaoImpl : Repository<Achat>, AchatDao {

    public async Task<Achat?> FindByReference(String reference){
        return await FindIf(el => el.Reference == reference);
    }

    public async Task<int>  DeleteByReference(String reference){
        return await DeleteIf(el => el.Reference == reference);
    }

    public new async Task<List<Achat>> FindOptimized() {
        return await IncludedTable.Select(e => new Achat{Id = e.Id, Reference = e.Reference}).ToListAsync();
    }

    public async Task<List<Achat>?> FindByClientId(long id) {
        return await FindListIf(item => item.Client!.Id == id);
    }
    public async Task<int> DeleteByClientId(long id) {
        return await DeleteIf(item => item.Client!.Id == id);
    }


    public AchatDaoImpl(AppDbContext context) : base(context, context.Achats){
    }
    protected override void SetContextEntry(Achat item){
        SetUnchangedEntry(item.Client);
        SetUnchangedEntry(item.AchatItems);
    }

    protected override IQueryable<Achat> SetIncluded() {
        return Table
        .Include(a => a.Client)
        .Include(a => a.AchatItems)
        ;
    }
}
