using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orders2025.Backend.Data;
using Orders2025.Backend.Repositories.Interfaces;
using Orders2025.Shared.Entities;
using Orders2025.Shared.Responses;

namespace Orders2025.Backend.Repositories.Implementations;

public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
{
    private readonly DataContext _context;

    public CountriesRepository(DataContext context) : base(context)
    {
        this._context = context;
    }

    public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync()
    {
        var countries = await _context.Countries.Include(x => x.States)!.ThenInclude(x => x.Cities).ToListAsync();
        return new ActionResponse<IEnumerable<Country>>
        {
            WasSuccess = true,
            Result = countries
        };
    }

    public override async Task<ActionResponse<Country>> GetAsync(int id)
    {
        var country = await _context.Countries.Include(x => x.States)!
                                              .ThenInclude(x => x.Cities)
                                              .FirstOrDefaultAsync(x => x.Id == id);

        if (country == null)
        {
            return new ActionResponse<Country>
            {
                WasSuccess = false,
                Message = "Registro no encpntrado."
            };
        }

        return new ActionResponse<Country>
        {
            WasSuccess = true,
            Result = country
        };
    }
}