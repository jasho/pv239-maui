﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PV239_06_API.Core.Config;
using PV239_06_API.Core.Models;
using PV239_06_API.Core.Services.Interfaces;
using SQLite;

namespace PV239_06_API.Core.Services
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

        public async Task<T> GetById<T>(Guid id)
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
            var resultId = model.Id == Guid.Empty
                ? await connection.InsertAsync(model)
                : await connection.UpdateAsync(model);

            await connection.CloseAsync();
            return resultId;
        }
    }
}