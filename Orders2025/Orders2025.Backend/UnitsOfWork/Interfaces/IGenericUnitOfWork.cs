using Orders2025.Shared.Responses;

namespace Orders2025.Backend.UnitsOfWork.Interfaces;

public interface IGenericUnitOfWork<T> where T : class
{
    Task<ActionResponse<T>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<T>>> GetAsync();

    Task<ActionResponse<T>> AddAsync(T entity);

    Task<ActionResponse<T>> UpdateAsync(T entity);

    Task<ActionResponse<T>> DeleteAsync(int id);
}