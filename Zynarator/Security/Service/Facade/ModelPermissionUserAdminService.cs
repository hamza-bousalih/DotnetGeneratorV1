using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Dao.Criteria;
using DotnetGenerator.Zynarator.Service;

namespace DotnetGenerator.Zynarator.Security.Service.Facade;

public interface ModelPermissionUserService : IService<ModelPermissionUser, ModelPermissionUserCriteria>
{
    Task<List<ModelPermissionUser>?> FindByActionPermissionId(long id);
    Task<int> DeleteByActionPermissionId(long id);
    Task<List<ModelPermissionUser>?> FindByModelPermissionId(long id);
    Task<int> DeleteByModelPermissionId(long id);
    Task<List<ModelPermissionUser>?> FindByUserId(long id);
    Task<int> DeleteByUserId(long id);
    
    Task<List<ModelPermissionUser>> InitModelPermissionUser();
    Task<long> CountByActionPermissionReference(String reference);
    Task<long> CountByModelPermissionReference(String reference);
    Task<bool> FindByUserUsernameAndModelPermissionReferenceAndActionPermissionReference(String username, String modelReference, String actionReference);
    Task<long> CountByUserEmail(String email);

}