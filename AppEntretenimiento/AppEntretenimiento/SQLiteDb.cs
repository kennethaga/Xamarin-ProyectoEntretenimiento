﻿using AppEntretenimiento.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppEntretenimiento
{
    public abstract class SQLiteDb
    {
        private SQLiteAsyncConnection _database;

        public SQLiteDb(string conexion)
        {
            _database = new SQLiteAsyncConnection(conexion);
        }

        public async Task IncludeAsync<T>() where T : class, new()
        {
            await _database.CreateTableAsync<T>();
        }

        public Task<List<T>> ListAsync<T>()
            where T : class, new()
        {
            // SELECT
            return _database.Table<T>().ToListAsync();
        }

        public Task<int> InsertAsync(mEntretenimiento item)
        {
            // INSERT
            return _database.InsertAsync(item);
        }

        public Task<int> DeleteAsync<T>(T item)
            where T : class, new()
        {
            // DELETE
            return _database.DeleteAsync(item);
        }

        public async Task InsertAllAsync<T>(IEnumerable<T> items)
            where T : class, new()
        {
            await _database.InsertAllAsync(items, runInTransaction: true);
        }

        public async Task DeleteAllAsync<T>()
            where T : class, new()
        {
            // DELETE * FROM [Productos]
            await _database.DeleteAllAsync<T>();
        }

        public async Task UpdateAsync<T>(T item)
            where T : class, new()
        {
            await _database.UpdateAsync(item);
        }
    }
}
