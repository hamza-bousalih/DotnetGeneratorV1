using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Repository;
using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Dao.Repository.Facade;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerator.Zynarator.Security.Dao.Repository.Impl;

public class RoleUserDaoImpl : Repository<RoleUser>, RoleUserDao
{
    public async Task<List<RoleUser>?> FindByUserId(long id)
    {
        return await FindListIf(item => item.User!.Id == id);
    }

    public async Task<int> DeleteByUserId(long id)
    {
        return await DeleteIf(item => item.User!.Id == id);
    }

    public async Task<List<RoleUser>?> FindByRoleId(long id)
    {
        return await FindListIf(item => item.Role!.Id == id);
    }

    public async Task<int> DeleteByRoleId(long id)
    {
        return await DeleteIf(item => item.Role!.Id == id);
    }


    public RoleUserDaoImpl(AppDbContext context) : base(context, context.RoleUsers)
    {
    }

    protected override void SetContextEntry(RoleUser item)
    {
        SetUnchangedEntry(item.User);
        SetUnchangedEntry(item.Role);
    }

    protected override IQueryable<RoleUser> SetIncluded()
    {
        return Table
                .Include(a => a.User)
                .Include(a => a.Role)
            ;
    }
}