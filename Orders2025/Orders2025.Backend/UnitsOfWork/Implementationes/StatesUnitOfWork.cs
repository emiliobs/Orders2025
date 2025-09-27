using Orders2025.Backend.Repositories.Interfaces;
using Orders2025.Backend.UnitsOfWork.Interfaces;
using Orders2025.Shared.Entities;
using Orders2025.Shared.Responses;

namespace Orders2025.Backend.UnitsOfWork.Implementationes;

public class StatesUnitOfWork : GenericUnitOfWork<State>, IStatesUnitOfWork
{
    private readonly IStatesRepository statesRepository;

    public StatesUnitOfWork(IGenericRepository<State> repository, IStatesRepository statesRepository) : base(repository)
    {
        this.statesRepository = statesRepository;
    }

    public override async Task<ActionResponse<IEnumerable<State>>> GetAsync() => await statesRepository.GetAsync();

    public override async Task<ActionResponse<State>> GetAsync(int id) => await statesRepository.GetAsync(id);
}