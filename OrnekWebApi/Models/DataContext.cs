using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace OrnekWebApi.Models;

public class DataContext : IdentityDbContext<AppUser, AppRole,int>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>().HasData(new Product() { Id = 1, ProductName = "Macbook Pro", IsActive = true, Price = 100000 });
        modelBuilder.Entity<Product>().HasData(new Product() { Id = 2, ProductName = "Macbook Air", IsActive = true, Price = 85000 });
        modelBuilder.Entity<Product>().HasData(new Product() { Id = 3, ProductName = "HP Computer", IsActive = false, Price = 90000 });
        modelBuilder.Entity<Product>().HasData(new Product() { Id = 4, ProductName = "MSI", IsActive = true, Price = 80000 });
    }
        public DbSet<Product> Products { get; set; }
}