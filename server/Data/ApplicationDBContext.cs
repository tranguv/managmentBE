using Microsoft.EntityFrameworkCore;
using System;
using server.Models;
using server.Configurations;
namespace server.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions dbContextOptions)
    : base(dbContextOptions)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var allEntities = modelBuilder.Model.GetEntityTypes();

        foreach (var entity in allEntities)
        {
            entity.AddProperty("CreatedDate", typeof(DateTime));
            entity.AddProperty("UpdatedDate", typeof(DateTime));
        }

        modelBuilder.Entity<Product_Category>().HasKey(pc => new { pc.CategoryId, pc.ProductId });
        new UserTypeConfiguration().Configure(modelBuilder.Entity<User>());
    }

    public override int SaveChanges()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e =>
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified);

        foreach (var entityEntry in entries)
        {
            entityEntry.Property("UpdatedDate").CurrentValue = DateTime.Now;

            if (entityEntry.State == EntityState.Added)
            {
                entityEntry.Property("CreatedDate").CurrentValue = DateTime.Now;
            }
        }

        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e =>
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified);

        foreach (var entityEntry in entries)
        {
            entityEntry.Property("UpdatedDate").CurrentValue = DateTime.Now;

            if (entityEntry.State == EntityState.Added)
            {
                entityEntry.Property("CreatedDate").CurrentValue = DateTime.Now;
            }
        }

        return base.SaveChangesAsync();
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Product_Category> Product_Categories { get; set; }
}
