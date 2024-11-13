using DesafioNexas.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioNexas.Infrastructure;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options){}
    
    public DbSet<Product> Products { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<StockItem> StockItems { get; set; }

    public void onModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasMany(p => p.StockItems)
            .WithOne(si => si.Product)
            .HasForeignKey(si => si.ProductId);
        
        modelBuilder.Entity<Store>()
            .HasMany(s => s.StockItems)
            .WithOne(si => si.Store)
            .HasForeignKey(si => si.StoreId);
    }
}