using DotnetGenerator.Zynarator.Repository;
using DotnetGenerator.Zynarator.Security.Bean;

namespace DotnetGenerator.Zynarator.Security.Dao.Repository.Facade;

public interface ModelPermissionDao : IRepository<ModelPermission>
{
    Task<ModelPermission?> FindByReference(String reference);
    Task<int> DeleteByReference(String reference);
}