using DotnetGenerator.Bean.Core;
using DotnetGenerator.Dao.Facade;
using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Repository;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerator.Dao.Impl;

public class AchatDaoImpl: Repository<Achat>, AchatDao
{
    public AchatDaoImpl(AppDbContext context, IEnumerable<Achat> table) : base(context, table)
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

    public async Task<int> DeleteByClient(int clientId) =>
        await DeleteIf(item => item.Client.Id == clientId);
}