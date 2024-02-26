using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Repository;
using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Dao.Repository.Facade;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerator.Zynarator.Security.Dao.Repository.Impl;

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
        return await DeleteIf(item => item.User != null && item.User.Id == id);
    }

    public async Task<long> CountByActionPermissionReference(string reference)
    {
        return await Table.Where(i => i.ActionPermission != null && i.ActionPermission.Reference == reference).CountAsync();
    }

    public async Task<long> CountByModelPermissionReference(string reference)
    {
        return await Table.Where(i => i.ModelPermission != null && i.ModelPermission.Reference == reference).CountAsync();
    }
    
    public async Task<long> CountByUserEmail(string email)
    {
        return await Table.Where(i => i.User != null && i.User.Email == email).CountAsync();
    }

    public async Task<ModelPermissionUser?> FindByUserUsernameAndModelReferenceAndActionReference(string username,
        string modelReference,
        string actionReference)
    {
        return await Table.FirstOrDefaultAsync(i =>
            i.ActionPermission != null &&
            i.ModelPermission != null &&
            i.User != null &&
            i.User.UserName == username &&
            i.ModelPermission.Reference == modelReference &&
            i.ActionPermission.Reference == actionReference
        );
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