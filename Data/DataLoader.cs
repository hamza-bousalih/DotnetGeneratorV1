using DotnetGenerator.Zynarator.Security.Bean;
using DotnetGenerator.Zynarator.Security.Common;
using DotnetGenerator.Zynarator.Security.Service.Facade;
using Lamar;

namespace DotnetGenerator.Data;

public class DataLoader
{
    private readonly AppDbContext _context;
    private readonly RoleService _roleService;
    private readonly UserService _userService;
    private readonly ModelPermissionService _modelPermissionService;
    private readonly ActionPermissionService _actionPermissionService;
    private readonly ModelPermissionUserService _modelPermissionUserService;

    public DataLoader(IContainer container, AppDbContext context)
    {
        _context = context;
        _roleService = container.GetInstance<RoleService>();
        _userService = container.GetInstance<UserService>();
        _modelPermissionService = container.GetInstance<ModelPermissionService>();
        _actionPermissionService = container.GetInstance<ActionPermissionService>();
        _modelPermissionUserService = container.GetInstance<ModelPermissionUserService>();
    }

    public async Task Load()
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var roles = new List<Role>
            {
                new(Roles.Admin),
                new(Roles.User)
            };
            await _roleService.Create(roles, false);

            // ModelPermissions For admin
            var modelPermissions = new List<ModelPermission>();
            AddPermissionForAdmin(modelPermissions);
            await _modelPermissionService.Create(modelPermissions, false);
            // ActionPermissions For admin
            var actionPermissions = new List<ActionPermission>();
            AddActionPermissionForAdmin(actionPermissions);
            await _actionPermissionService.Create(actionPermissions, false);
            
            var userForAdmin = new User("admin") { Password = "123" };
            var roleForAdmin = new Role { Authority = Roles.Admin };
            var roleUser = new RoleUser { Role = roleForAdmin };

            userForAdmin.RoleUsers ??= (new List<RoleUser>());
            userForAdmin.RoleUsers.Add(roleUser);

            userForAdmin.ModelPermissionUsers ??= (new List<ModelPermissionUser>());
            userForAdmin.ModelPermissionUsers = await _modelPermissionUserService.InitModelPermissionUser();

            await _userService.Create(userForAdmin, false);

            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public void AddPermissionForAdmin(List<ModelPermission> modelPermissions)
    {
        modelPermissions.Add(new ModelPermission {Reference = "Client" });
        modelPermissions.Add(new ModelPermission {Reference = "Achat" });
        modelPermissions.Add(new ModelPermission {Reference = "AchatItem" });
        modelPermissions.Add(new ModelPermission {Reference = "Produit" });
    }

    public void AddActionPermissionForAdmin(List<ActionPermission> actionPermissions)
    {
        actionPermissions.Add(new ActionPermission { Reference = "list" });
        actionPermissions.Add(new ActionPermission { Reference = "create" });
        actionPermissions.Add(new ActionPermission { Reference = "delete" });
        actionPermissions.Add(new ActionPermission { Reference = "edit" });
        actionPermissions.Add(new ActionPermission { Reference = "view" });
        actionPermissions.Add(new ActionPermission { Reference = "duplicate" });
    }
}