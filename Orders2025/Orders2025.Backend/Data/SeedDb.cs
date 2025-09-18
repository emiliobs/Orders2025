using Orders2025.Shared.Entities;

namespace Orders2025.Backend.Data;

public class SeedDb
{
    private readonly DataContext _context;

    public SeedDb(DataContext context)
    {
        this._context = context;
    }

    public async Task SeedDbAsync()
    {
        await this._context.Database.EnsureCreatedAsync();
        await this.CheckCountriesAsync();
        await this.CheckCategoriesAsync();
        //        await this.CheckProductsAsync();
        //        await this.CheckRolesAsync();
        //        await this.CheckUserAsync("1010", "Juan", "Perez", "
    }

    private async Task CheckCategoriesAsync()
    {
        if (!_context.Categories.Any())
        {
            this._context.Categories.Add(new Category { Name = "Calzado" });
            this._context.Categories.Add(new Category { Name = "Tecnologíá" });
            this._context.Categories.Add(new Category { Name = "Ropa" });
            this._context.Categories.Add(new Category { Name = "Hogar" });
            this._context.Categories.Add(new Category { Name = "Libros" });
            await this._context.SaveChangesAsync();
        }
    }

    private async Task CheckCountriesAsync()
    {
        if (!_context.Countries.Any())
        {
            this._context.Countries.Add(new Country { Name = "Colombia" });
            this._context.Countries.Add(new Country { Name = "Argentina" });
            this._context.Countries.Add(new Country { Name = "Mexico" });
            this._context.Countries.Add(new Country { Name = "Peru" });
            this._context.Countries.Add(new Country { Name = "Chile" });
            await this._context.SaveChangesAsync();
        }
    }
}