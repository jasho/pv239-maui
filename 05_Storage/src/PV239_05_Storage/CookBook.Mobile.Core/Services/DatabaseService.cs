using CookBook.Mobile.Core.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CookBook.Mobile.Core.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly string databasePath;

        public DatabaseService()
        {
            databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.db3");
        }

        public async Task<CreateTableResult> CreateTableAsync<T>()
            where T : EntityBase, new()
        {
            var connection = new SQLiteAsyncConnection(databasePath);
            var result = await connection.CreateTableAsync<T>();
            await connection.CloseAsync();
            return result;
        }

        public async Task<List<T>> GetAllAsync<T>()
            where T : new()
        {
            var connection = new SQLiteAsyncConnection(databasePath);
            var result = await connection.Table<T>().ToListAsync();
            await connection.CloseAsync();
            return result;
        }

        public async Task<T> GetByIdAsync<T>(Guid id)
            where T : EntityBase, new()
        {
            var connection = new SQLiteAsyncConnection(databasePath);
            var result = await connection.Table<T>().Where(model => model.Id == id).FirstOrDefaultAsync();
            await connection.CloseAsync();
            return result;
        }

        public async Task SetAsync<T>(T entity)
            where T : EntityBase, new()
        {
            var connection = new SQLiteAsyncConnection(databasePath);
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
                await connection.InsertAsync(entity);
            }
            else
            {
                await connection.UpdateAsync(entity);
            }
            await connection.CloseAsync();
        }
    }
}