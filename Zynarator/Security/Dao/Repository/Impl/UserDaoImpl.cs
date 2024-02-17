
using DotnetGenerator.Data;
using DotnetGenerator.Zynarator.Repository;
using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Dao.Repository.Facade;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerator.Dao.Impl;

public class UserDaoImpl : Repository<User>, UserDao
{
    public async Task<User?> FindByUsername(String username)
    {
        return await FindIf(el => el.Username == username);
    }

    public async Task<int> DeleteByUsername(String username)
    {
        return await DeleteIf(el => el.Username == username);
    }

    public new async Task<List<User>> FindOptimized()
    {
        return await IncludedTable.Select(e => new User { Id = e.Id, Username = e.Username }).ToListAsync();
    }


    public UserDaoImpl(AppDbContext context) : base(context, context.Users)
    {
    }

    protected override void SetContextEntry(User item)
    {
        SetUnchangedEntry(item.RoleUsers);
        SetUnchangedEntry(item.ModelPermissionUsers);
    }

    protected override IQueryable<User> SetIncluded()
    {
        return Table
                .Include(a => a.RoleUsers)
                .Include(a => a.ModelPermissionUsers)
            ;
    }
}