using Microsoft.EntityFrameworkCore;
using Orders2025.Shared.Entities;

namespace Orders2025.Backend.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Country> Countries { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Country>().HasIndex(X => X.Name).IsUnique();
        modelBuilder.Entity<Category>().HasIndex(X => X.Name).IsUnique();
    }
}