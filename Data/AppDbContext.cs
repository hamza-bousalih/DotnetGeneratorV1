using DotnetGenerator.Bean.Core;
using DotnetGenerator.Zynarator.Audit;
using DotnetGenerator.Zynarator.Security.Bean;
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
    public DbSet<RoleUser> RoleUsers { get; init; }
    // public DbSet<Role> Roles { get; init; }
    public DbSet<ModelPermissionUser> ModelPermissionUsers { get; init; }
    public DbSet<ActionPermission> ActionPermissions { get; init; }
    public DbSet<ModelPermission> ModelPermissions { get; init; }
    // public DbSet<User> Users { get; init; }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<decimal>().HaveColumnType("decimal(18,2)");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.RegisterEntities();
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
