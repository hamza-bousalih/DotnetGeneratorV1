using DotnetGenerator.Bean.Core;
using DotnetGenerator.Zynarator.Audit;
using DotnetGenerator.Zynarator.Security.Bean;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerator.Data;

public class AppDbContext : IdentityDbContext<User, Role, long, IdentityUserClaim<long>, RoleUser, IdentityUserLogin<long>, IdentityRoleClaim<long>, IdentityUserToken<long>>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public required DbSet<Client> Clients { get; init; }
    public required DbSet<Achat> Achats { get; init; }
    public required DbSet<AchatItem> AchatItems { get; init; }
    public required DbSet<Produit> Produits { get; init; }

    // For Security
    public override required DbSet<User> Users { get; set; }
    public override required DbSet<Role> Roles { get; set; }
    public override required DbSet<RoleUser> UserRoles { get; set; }
    public required DbSet<ModelPermissionUser> ModelPermissionUsers { get; init; }
    public required DbSet<ActionPermission> ActionPermissions { get; init; }
    public required DbSet<ModelPermission> ModelPermissions { get; init; }
    
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<decimal>().HaveColumnType("decimal(18,2)");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
     
        modelBuilder.Entity<User>().ToTable("User");
        modelBuilder.Entity<Role>().ToTable("Role");

        modelBuilder.Entity<RoleUser>()
            .HasKey(ru => ru.Id);

        modelBuilder.Entity<RoleUser>().ToTable("RoleUser");

        modelBuilder.Entity<RoleUser>()
            .HasOne(ru => ru.User)
            .WithMany(u => u!.RoleUsers)
            .HasForeignKey(ru => ru.UserId)
            .IsRequired();

        modelBuilder.Entity<RoleUser>()
            .HasOne(ru => ru.Role)
            .WithMany(r => r!.RoleUsers)
            .HasForeignKey(ru => ru.RoleId)
            .IsRequired();
        
        modelBuilder.Entity<IdentityUserClaim<long>>().ToTable("UserClaim");
        modelBuilder.Entity<IdentityUserLogin<long>>().ToTable("UserLogin");
        modelBuilder.Entity<IdentityRoleClaim<long>>().ToTable("RoleClaim");
        modelBuilder.Entity<IdentityUserToken<long>>().ToTable("UserToken");
        
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