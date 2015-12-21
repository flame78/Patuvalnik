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

        private SQLiteAsyncConnection Connection
        {
            get { if (this.connection == null)
                {
                    this.connection = new SQLiteAsyncConnection(dbName);
                }
                return this.connection;
            }
        }

        public List<KeyString> data { get; set; }

        public SQLiteDataProvider()
        {
            this.InitSql();
        }

        public async Task<List<KeyString>> GetData()
        {
            var query = Connection.Table<KeyString>();
            data = await query.ToListAsync();

            return data;
        }

        public async Task AddKeyStringAsync(KeyString value)
        {
           
            await Connection.InsertAsync(value);
        }

        public async Task RemoveKeyStringAsync(KeyString value)
        {

            await Connection.DeleteAsync(value);
        }

        public async void InitSql()
        {
            bool dbExists = await CheckDbAsync(dbName);
            if (!dbExists)
            {
                CreateDatabaseAsync();
                AddTableAsync();
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

        private async Task AddTableAsync()
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

        #endregion SQLite utils


    }
}
