using CookBook.Mobile.Entities;
using SQLite;

namespace CookBook.Mobile.Services;

public interface IDatabaseService
{
    Task<CreateTableResult> CreateTableAsync<T>()
        where T : EntityBase, new();

    Task<List<T>> GetAllAsync<T>()
        where T : new();

    Task<T> GetByIdAsync<T>(Guid id)
        where T : EntityBase, new();

    Task SetAsync<T>(T entity)
        where T : EntityBase, new();
}