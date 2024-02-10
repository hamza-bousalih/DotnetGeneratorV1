namespace DotnetGenerator.Zynarator.Audit;

using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public static class EntityListener
{
    public static void RegisterEntities(this ModelBuilder modelBuilder)
    {
        var auditableEntityTypes = modelBuilder.Model.GetEntityTypes()
            .Where(e => typeof(AuditBusinessObject).IsAssignableFrom(e.ClrType));

        foreach (var entityType in auditableEntityTypes)
        {
            modelBuilder.Entity(entityType.ClrType)
                .Property<DateTime>("CreatedOn")
                .IsRequired();
            modelBuilder.Entity(entityType.ClrType)
                .Property<string>("CreatedBy")
                .IsRequired();
            modelBuilder.Entity(entityType.ClrType)
                .Property<DateTime?>("UpdatedOn");
            modelBuilder.Entity(entityType.ClrType)
                .Property<string?>("UpdatedBy");
        }
    }

    public static void HandleAuditableEntities(this EntityEntry entry)
    {
        if (entry.Entity is not AuditBusinessObject auditableEntity) return;
        var currentTime = DateTime.UtcNow;
        var currentUsername = GetCurrentUsername();

        switch (entry.State)
        {
            case EntityState.Added:
                auditableEntity.CreatedOn = currentTime;
                auditableEntity.CreatedBy = currentUsername;
                break;
            case EntityState.Modified:
                entry.Property("CreatedOn").IsModified = false;
                entry.Property("CreatedBy").IsModified = false;
                auditableEntity.UpdatedOn = currentTime;
                auditableEntity.UpdatedBy = currentUsername;
                break;
        }
    }

    private static string GetCurrentUsername()
    {
        var username = ClaimsPrincipal.Current?.Identity?.Name;
        return username ?? "System"; // Default user
    }
}