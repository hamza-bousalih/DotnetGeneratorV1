using DotnetGenerator.Bean.Core;
using DotnetGenerator.Zynarator.Audit;
using DotnetGenerator.Zynarator.Security.Bean;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerator.Data;

public class AppDbContext : IdentityDbContext<User, Role, long>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public required DbSet<Client> Clients { get; init; }
    public required DbSet<Achat> Achats { get; init; }
    public required DbSet<AchatItem> AchatItems { get; init; }
    public required DbSet<Produit> Produits { get; init; }

    // For Security
    // public override required DbSet<User> Users { get; set; }
    // public override required DbSet<Role> Roles { get; set; }
    public required DbSet<RoleUser> RoleUsers { get; init; }
    public required DbSet<ModelPermissionUser> ModelPermissionUsers { get; init; }
    public required DbSet<ActionPermission> ActionPermissions { get; init; }
    public required DbSet<ModelPermission> ModelPermissions { get; init; }
    
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<decimal>().HaveColumnType("decimal(18,2)");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>().ToTable("User");
        builder.Entity<Role>().ToTable("Role");

        builder.Entity<IdentityUserRole<long>>().ToTable("UserRole");
        builder.Entity<IdentityUserClaim<long>>().ToTable("UserClaim");
        builder.Entity<IdentityUserLogin<long>>().ToTable("UserLogin");

        builder.Entity<IdentityRoleClaim<long>>().ToTable("RoleClaim");
        builder.Entity<IdentityUserToken<long>>().ToTable("UserToken");
        
        builder.RegisterEntities();
     
        base.OnModelCreating(builder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyEntityChanges();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void ApplyEntityChanges()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.State is EntityState.Added or EntityState.Modified);
        foreach (var entry in entries)
            entry.HandleAuditableEntities();
    }
}