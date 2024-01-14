using DotnetGenerator.Bean;
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
}