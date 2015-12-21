using Patuvalnik.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Patuvalnik.DataProvider
{
    public class SQLiteDataProvider
    {
        private const string dbName = "Patuvalnik.db";

        private SQLiteAsyncConnection connection;

        public List<KeyString> data { get; set; }

        public SQLiteDataProvider()
        {
        }

        public async Task<List<KeyString>> GetData()
        {
            var query = connection.Table<KeyString>();
            data = await query.ToListAsync();

            return data;
        }

        public async void InitSql()
        {
            bool dbExists = await CheckDbAsync(dbName);
            if (!dbExists)
            {
                CreateDatabaseAsync();
                AddTripsAsync();
            }

            connection = new SQLiteAsyncConnection(dbName);
        }
        #region SQLite utils
        private async Task<bool> CheckDbAsync(string dbName)
        {
            bool dbExist = true;

            try
            {
                StorageFile sf = await ApplicationData.Current.LocalFolder.GetFileAsync(dbName);
            }
            catch (Exception)
            {
                dbExist = false;
            }

            return dbExist;
        }

        private async Task CreateDatabaseAsync()
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
            await conn.CreateTableAsync<KeyString>();
        }

        private async Task AddTripsAsync()
        {
            var list = new List<KeyString>()
            {
                new KeyString()
                {
                }
            };

            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
            await conn.InsertAllAsync(list);
        }

        private async Task DeleteTripsAsync(Trip trip)
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);

            if (trip != null)
            {
                await conn.DeleteAsync(trip);
            }
        }

        private async Task DropTableAsync()
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
            await conn.DropTableAsync<Trip>();
        }

        #endregion SQLite utils


    }
}
