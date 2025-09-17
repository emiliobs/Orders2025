using Microsoft.EntityFrameworkCore;
using Orders2025.Backend.Data;
using Orders2025.Backend.Repositories.Interfaces;
using Orders2025.Shared.Responses;

namespace Orders2025.Backend.Repositories.Implementations;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DataContext _context;
    private readonly DbSet<T> _entity;

    public GenericRepository(DataContext context)
    {
        this._context = context;
        this._entity = context.Set<T>();
    }

    public async Task<ActionResponse<T>> AddAsync(T entity)
    {
        _context.Add(entity);
        try
        {
            await _context.SaveChangesAsync();
            return new ActionResponse<T>
            {
                WasSuccess = true,
                Result = entity
            };
        }
        catch (DbUpdateException)
        {
            return DbUpdateExceptionActionResponse();
        }
        catch (Exception exception)
        {
            return ExceptionActionResponse(exception);
        }
    }

    public async Task<ActionResponse<T>> DeleteAsync(int id)
    {
        var row = await _entity.FindAsync(id);
        if (row == null)
        {
            return new ActionResponse<T>
            {
                WasSuccess = false,
                Message = "El registro no existe."
            };
        }

        _entity.Remove(row);

        try
        {
            await _context.SaveChangesAsync();
            return new ActionResponse<T>
            {
                WasSuccess = true,
            };
        }
        catch
        {
            return new ActionResponse<T>
            {
                WasSuccess = false,
                Message = "No se puede eliminar el registro porque tiene datos relacionados."
            };
        }
    }

    public async Task<ActionResponse<T>> GetAsync(int id)
    {
        var row = await _entity.FindAsync(id);
        if (row == null)
        {
            return new ActionResponse<T>
            {
                WasSuccess = false,
                Message = "El registro no existe."
            };
        }

        return new ActionResponse<T>
        {
            WasSuccess = true,
            Result = row
        };
    }

    public async Task<ActionResponse<IEnumerable<T>>> GetAsync() => new ActionResponse<IEnumerable<T>>
    {
        WasSuccess = true,
        Result = await _entity.ToListAsync()
    };

    public async Task<ActionResponse<T>> UpdateAsync(T entity)
    {
        _context.Update(entity);
        try
        {
            await _context.SaveChangesAsync();
            return new ActionResponse<T>
            {
                WasSuccess = true,
                Result = entity
            };
        }
        catch (DbUpdateException)
        {
            return DbUpdateExceptionActionResponse();
        }
        catch (Exception exception)
        {
            return ExceptionActionResponse(exception);
        }
    }

    private ActionResponse<T> DbUpdateExceptionActionResponse() => new ActionResponse<T>
    {
        WasSuccess = false,
        Message = "Ya existe el registro."
    };

    private ActionResponse<T> ExceptionActionResponse(Exception exception) => new ActionResponse<T>
    {
        WasSuccess = false,
        Message = exception.Message
    };
}