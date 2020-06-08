using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Gym.Models;
using System.Threading.Tasks;

namespace Gym.Data
{
    public class RepDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public RepDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Rep>().Wait();
        }

        public Task<List<Rep>> GetRepsAsync()
        {
            return _database.Table<Rep>().ToListAsync();
        }

        public Task<Rep> GetRepAsync(int id)
        {
            return _database.Table<Rep>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveRepAsync (Rep rep)
        {
            if (rep.ID != 0)
            {
                return _database.UpdateAsync(rep);
            }
            else
            {
                return _database.InsertAsync(rep);
            }
        }
        public Task<int> DeleteRepAsync(Rep rep)
        {
            return _database.DeleteAsync(rep);
        }

        public Task<int> DeleteRepsAsync()
        {
            return _database.DeleteAllAsync<Rep>();
        }
    }
}
