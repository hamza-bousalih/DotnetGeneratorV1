using DotnetGenerator.Bean.Core;
using DotnetGenerator.Zynarator.Audit;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerator.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Achat> Achats { get; init; }
    public DbSet<Client> Clients { get; init; }
    public DbSet<Produit> Produits { get; init; }

    public DbSet<AchatItem> AchatItems { get; init; }

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