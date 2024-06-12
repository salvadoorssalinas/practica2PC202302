using pc202302.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using pc202302.Logistics.Domain.Model.Aggregates;

namespace pc202302.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }
    
    public DbSet<Inventory> Inventories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Logistics Context
        
        // Inventories table
        builder.Entity<Inventory>().HasKey(p => p.Id);
        builder.Entity<Inventory>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Inventory>().Property(p => p.ProductId).IsRequired();
        builder.Entity<Inventory>().Property(p => p.WarehouseId).IsRequired();
        builder.Entity<Inventory>().Property(p => p.MinimumStock).IsRequired();
        builder.Entity<Inventory>().Property(p => p.CurrentStock).IsRequired();
        builder.Entity<Inventory>().Property(p => p.Type).IsRequired().HasMaxLength(20);
        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}