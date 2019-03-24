using System.Collections.Generic;
using System.Threading.Tasks;
using PV239_05_Storage.Core.Models;
using SQLite;

namespace PV239_05_Storage.Core.Services.Interfaces
{
    public interface IDatabaseService : ITransientService
    {
        Task<List<T>> GetAll<T>()
            where T : new();

        Task<T> GetById<T>(int id)
            where T : ModelBase, new();

        Task<int> Set<T>(T model)
            where T : ModelBase, new();

        Task<CreateTableResult> CreateTable<T>()
            where T : ModelBase, new();
    }
}