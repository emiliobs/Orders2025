using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orders2025.Backend.UnitsOfWork.Interfaces;
using Orders2025.Shared.Entities;

namespace Orders2025.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CitiesController : GenericController<City>
{
    public CitiesController(IGenericUnitOfWork<City> unitOfWork) : base(unitOfWork)
    {
    }
}