
using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Repository;
using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Dao.Repository.Facade;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerator.Dao.Impl;

public class ModelPermissionDaoImpl : Repository<ModelPermission>, ModelPermissionDao
{
    public async Task<ModelPermission?> FindByReference(String reference)
    {
        return await FindIf(el => el.Reference == reference);
    }

    public async Task<int> DeleteByReference(String reference)
    {
        return await DeleteIf(el => el.Reference == reference);
    }

    public new async Task<List<ModelPermission>> FindOptimized()
    {
        return await IncludedTable.Select(e => new ModelPermission { Id = e.Id, Reference = e.Reference })
            .ToListAsync();
    }


    public ModelPermissionDaoImpl(AppDbContext context) : base(context, context.ModelPermissions)
    {
    }
}