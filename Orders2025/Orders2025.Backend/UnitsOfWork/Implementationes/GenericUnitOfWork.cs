using Orders2025.Backend.Repositories.Interfaces;
using Orders2025.Backend.UnitsOfWork.Interfaces;
using Orders2025.Shared.Responses;

namespace Orders2025.Backend.UnitsOfWork.Implementationes;

public class GenericUnitOfWork<T> : IGenericUnitOfWork<T> where T : class
{
    private readonly Repositories.Interfaces.IGenericRepository<T> _repository;

    public GenericUnitOfWork(IGenericRepository<T> repository)
    {
        this._repository = repository;
    }

    public virtual async Task<ActionResponse<T>> AddAsync(T entity) => await _repository.AddAsync(entity);

    public virtual async Task<ActionResponse<T>> DeleteAsync(int id) => await _repository.DeleteAsync(id);

    public virtual async Task<ActionResponse<T>> GetAsync(int id) => await _repository.GetAsync(id);

    public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync() => await _repository.GetAsync();

    public virtual async Task<ActionResponse<T>> UpdateAsync(T entity) => await _repository.UpdateAsync(entity);
}