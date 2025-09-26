using Microsoft.EntityFrameworkCore;
using Orders2025.Shared.Entities;

namespace Orders2025.Backend.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<State> States { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Category>().HasIndex(X => X.Name).IsUnique();
        modelBuilder.Entity<Country>().HasIndex(X => X.Name).IsUnique();
        modelBuilder.Entity<City>().HasIndex(X => new { X.Name, X.StateId }).IsUnique();
        modelBuilder.Entity<State>().HasIndex(X => new { X.Name, X.CountryId }).IsUnique();

        DisableCascadeDelete(modelBuilder);
    }

    private void DisableCascadeDelete(ModelBuilder modelBuilder)
    {
        var relationShips = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());
        foreach (var relationship in relationShips)
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}