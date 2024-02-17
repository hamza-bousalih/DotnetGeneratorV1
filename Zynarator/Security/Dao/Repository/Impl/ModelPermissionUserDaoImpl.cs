
using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Repository;
using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Dao.Repository.Facade;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerator.Dao.Impl;

public class ModelPermissionUserDaoImpl : Repository<ModelPermissionUser>, ModelPermissionUserDao
{
    public async Task<List<ModelPermissionUser>?> FindByActionPermissionId(long id)
    {
        return await FindListIf(item => item.ActionPermission!.Id == id);
    }

    public async Task<int> DeleteByActionPermissionId(long id)
    {
        return await DeleteIf(item => item.ActionPermission!.Id == id);
    }

    public async Task<List<ModelPermissionUser>?> FindByModelPermissionId(long id)
    {
        return await FindListIf(item => item.ModelPermission!.Id == id);
    }

    public async Task<int> DeleteByModelPermissionId(long id)
    {
        return await DeleteIf(item => item.ModelPermission!.Id == id);
    }

    public async Task<List<ModelPermissionUser>?> FindByUserId(long id)
    {
        return await FindListIf(item => item.User!.Id == id);
    }

    public async Task<int> DeleteByUserId(long id)
    {
        return await DeleteIf(item => item.User!.Id == id);
    }


    public ModelPermissionUserDaoImpl(AppDbContext context) : base(context, context.ModelPermissionUsers)
    {
    }

    protected override void SetContextEntry(ModelPermissionUser item)
    {
        SetUnchangedEntry(item.ActionPermission);
        SetUnchangedEntry(item.ModelPermission);
        SetUnchangedEntry(item.User);
    }

    protected override IQueryable<ModelPermissionUser> SetIncluded()
    {
        return Table
                .Include(a => a.ActionPermission)
                .Include(a => a.ModelPermission)
                .Include(a => a.User)
            ;
    }
}