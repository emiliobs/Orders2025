using Microsoft.AspNetCore.Mvc;
using Orders2025.Shared.Entities;
using Orders2025.Shared.Responses;

namespace Orders2025.Backend.Repositories.Interfaces;

public interface ICountriesRepository
{
    Task<ActionResponse<Country>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<Country>>> GetAsync();
}