using DotnetGenerator.Zynarator.Repository;
using DotnetGenerator.Zynarator.Security.Bean;

namespace DotnetGenerator.Zynarator.Security.Dao.Repository.Facade;

public interface ActionPermissionDao : IRepository<ActionPermission>
{
    Task<ActionPermission?> FindByReference(string reference);
    Task<int> DeleteByReference(string reference);
}