using DotnetGenerator.Bean.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotnetGenerator.Data.Configurations;

public class ProduitConfig : IEntityTypeConfiguration<Produit>
{
    public void Configure(EntityTypeBuilder<Produit> builder)
    {
        // builder.Property(p => p.SeuilAlert).HasColumnType("decimal(18,2)");
    }
}