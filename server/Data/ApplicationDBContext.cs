using Microsoft.EntityFrameworkCore;
using System;
using server.Models;
namespace server.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions dbContextOptions)
    : base(dbContextOptions)
    {

    }

    public override int SaveChanges()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is DateTimeEntity && (
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            ((DateTimeEntity)entityEntry.Entity).UpdatedDate = (DateTimeEntity)DateTime.Now;

            if (entityEntry.State == EntityState.Added)
            {
                ((DateTimeEntity)entityEntry.Entity).CreatedDate = (DateTimeEntity)DateTime.Now;
            }
        }

        return base.SaveChanges();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product_Category>().HasKey(pc => new { pc.CategoryId, pc.ProductId });
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Product_Category> Product_Categories { get; set; }
}
