using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PV239_06_API.Core.Models;
using SQLite;

namespace PV239_06_API.Core.Services.Interfaces
{
    public interface IDatabaseService : ITransientService
    {
        Task<List<T>> GetAll<T>()
            where T : new();

        Task<T> GetById<T>(Guid id)
            where T : ModelBase, new();

        Task<int> Set<T>(T model)
            where T : ModelBase, new();

        Task<CreateTableResult> CreateTable<T>()
            where T : ModelBase, new();
    }
}