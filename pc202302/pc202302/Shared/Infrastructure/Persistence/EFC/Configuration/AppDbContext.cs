using pc202302.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
//using pc202302.Logistics.Domain.Model.Entities;

namespace pc202302.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }
    
    //public DbSet<Plan> Plans { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Subscriptions Context
        
        // Plans table
        // builder.Entity<Plan>().HasKey(p => p.Id);
        // builder.Entity<Plan>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        // builder.Entity<Plan>().Property(p => p.Name).IsRequired().HasMaxLength(100);
        // builder.Entity<Plan>().Property(p => p.MaxUsers).IsRequired();
        // builder.Entity<Plan>().Property(p => p.IsDefault).IsRequired();
        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}