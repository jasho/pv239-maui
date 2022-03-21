using CookBook.Mobile.Core.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBook.Mobile.Core.Services
{
    public interface IDatabaseService
    {
        Task<List<T>> GetAllAsync<T>()
            where T : new();

        Task<T> GetByIdAsync<T>(Guid id)
            where T : EntityBase, new();

        Task SetAsync<T>(T entity)
            where T : EntityBase, new();

        Task<CreateTableResult> CreateTableAsync<T>()
            where T : EntityBase, new();
    }
}