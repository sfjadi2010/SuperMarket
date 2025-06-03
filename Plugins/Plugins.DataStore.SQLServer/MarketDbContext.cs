﻿using Microsoft.EntityFrameworkCore;
using SuperMarketManager.CoreBusiness;

namespace Plugins.DataStore.SQLServer;

public class MarketDbContext : DbContext
{
    public MarketDbContext(DbContextOptions<MarketDbContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Transaction> Transactions { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);

        // seeding some data
        modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Beverage", Description = "Beverage" },
                new Category { Id = 2, Name = "Bakery", Description = "Bakery" },
                new Category { Id = 3, Name = "Meat", Description = "Meat" }
            );

        modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, CategoryId = 1, Name = "Iced Tea", Quantity = 100, Price = 1.99 },
                new Product { Id = 2, CategoryId = 1, Name = "Canada Dry", Quantity = 200, Price = 1.99 },
                new Product { Id = 3, CategoryId = 2, Name = "Whole Wheat Bread", Quantity = 300, Price = 1.50 },
                new Product { Id = 4, CategoryId = 2, Name = "White Bread", Quantity = 300, Price = 1.50 }
            );

    }
}
