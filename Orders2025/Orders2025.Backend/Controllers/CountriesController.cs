using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orders2025.Backend.Data;
using Orders2025.Shared.Entities;

namespace Orders2025.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountriesController : ControllerBase
{
    private readonly DataContext _dataContext;

    public CountriesController(DataContext dataContext)
    {
        this._dataContext = dataContext;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _dataContext.Countries.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Post(Country country)
    {
        _dataContext.Countries.Add(country);
        await _dataContext.SaveChangesAsync();
        return Ok(country);
    }
}