using DotnetGenerator.Zynarator.Repository;
using DotnetGenerator.Zynarator.Security.Bean;

namespace DotnetGenerator.Zynarator.Security.Dao.Repository.Facade;

public interface ModelPermissionUserDao : IRepository<ModelPermissionUser>
{
    Task<List<ModelPermissionUser>?> FindByActionPermissionId(long id);
    Task<int> DeleteByActionPermissionId(long id);
    Task<List<ModelPermissionUser>?> FindByModelPermissionId(long id);
    Task<int> DeleteByModelPermissionId(long id);
    Task<List<ModelPermissionUser>?> FindByUserId(long id);
    Task<int> DeleteByUserId(long id);
}