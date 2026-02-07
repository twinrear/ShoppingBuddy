using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using ShoppingBuddy.Models.Entities;

namespace ShoppingBuddy.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
    {}

    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<ShoppingItem> ShoppingItems { get; set; } = null!;
    public DbSet<Store> Stores { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ShoppingItem>()
            .HasMany(item => item.Categories)
            .WithMany(category => category.Items);
    }
}