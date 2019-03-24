using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using PV239_05_Storage.Core.Config;
using PV239_05_Storage.Core.Models;
using PV239_05_Storage.Core.Services.Interfaces;
using SQLite;

namespace PV239_05_Storage.Core.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly IAppConfig appConfig;

        public DatabaseService(IAppConfig appConfig)
        {
            this.appConfig = appConfig;
        }

        public async Task<CreateTableResult> CreateTable<T>()
            where T : ModelBase, new()
        {
            var connection = new SQLiteAsyncConnection(appConfig.DatabasePath);
            var result = await connection.CreateTableAsync<T>();
            await connection.CloseAsync();
            return result;
        }

        public async Task<List<T>> GetAll<T>()
            where T : new()
        {
            var connection = new SQLiteAsyncConnection(appConfig.DatabasePath);
            var result = await connection.Table<T>().ToListAsync();
            await connection.CloseAsync();
            return result;
        }

        public async Task<T> GetById<T>(int id)
            where T : ModelBase, new()
        {
            var connection = new SQLiteAsyncConnection(appConfig.DatabasePath);
            var result = await connection.Table<T>().Where(model => model.Id == id).FirstOrDefaultAsync();
            await connection.CloseAsync();
            return result;
        }

        public async Task<int> Set<T>(T model)
            where T : ModelBase, new()
        {
            var connection = new SQLiteAsyncConnection(appConfig.DatabasePath);
            var resultId = model.Id == 0
                ? await connection.InsertAsync(model)
                : await connection.UpdateAsync(model);

            await connection.CloseAsync();
            return resultId;
        }
    }
}