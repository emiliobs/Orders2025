using Microsoft.AspNetCore.Mvc;
using Orders2025.Backend.UnitsOfWork.Interfaces;
using Orders2025.Shared.Entities;

namespace Orders2025.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountriesController : GenericController<Country>
{
    private readonly ICountriesUnitOfWork _countriesUnitOfWork;

    public CountriesController(IGenericUnitOfWork<Country> unitOfWork, ICountriesUnitOfWork countriesUnitOfWork) : base(unitOfWork)
    {
        this._countriesUnitOfWork = countriesUnitOfWork;
    }

    [HttpGet]
    public override async Task<IActionResult> GetAsync()
    {
        var action = await _countriesUnitOfWork.GetAsync();
        if (action.WasSuccess)
        {
            return BadRequest(action.Result);
        }
        return BadRequest(action.Message);
    }

    [HttpGet("{id}")]
    public override async Task<IActionResult> GetAsync(int id)
    {
        var action = await _countriesUnitOfWork.GetAsync(id);
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }
        return NotFound();
    }
}