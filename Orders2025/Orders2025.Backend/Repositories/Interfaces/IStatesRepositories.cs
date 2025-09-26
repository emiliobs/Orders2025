using Orders2025.Shared.Entities;
using Orders2025.Shared.Responses;

namespace Orders2025.Backend.Repositories.Interfaces;

public interface IStatesRepositories
{
    Task<ActionResponse<Country>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<Country>>> GetAsync();
}