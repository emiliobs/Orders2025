using Microsoft.AspNetCore.Mvc;
using Orders2025.Shared.Entities;
using Orders2025.Shared.Responses;

namespace Orders2025.Backend.UnitsOfWork.Interfaces;

public interface ICountriesUnitOfWork
{
    Task<ActionResponse<Country>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<Country>>> GetAsync();
}