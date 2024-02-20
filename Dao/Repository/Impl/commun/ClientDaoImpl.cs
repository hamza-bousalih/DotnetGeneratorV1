using DotnetGenerator.Bean.Core;
using DotnetGenerator.Dao.Facade;
using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Repository;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerator.Dao.Impl;

public class ClientDaoImpl : Repository<Client>, ClientDao
{
    public async Task<Client?> FindByCin(string cin)
    {
        return await FindIf(el => el.Cin == cin);
    }

    public async Task<int> DeleteByCin(string cin)
    {
        return await DeleteIf(el => el.Cin == cin);
    }

    public new async Task<List<Client>> FindOptimized()
    {
        return await IncludedTable.Select(e => new Client { Id = e.Id, Nom = e.Nom }).ToListAsync();
    }


    public ClientDaoImpl(AppDbContext context) : base(context, context.Clients)
    {
    }
}