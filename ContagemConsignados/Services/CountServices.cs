
using ContagemConsignados.AppDataBase;
using ContagemConsignados.Mvvm.Model;
using ContagemConsignados.Services.Interface;
using SQLite;

namespace ContagemConsignados.Services
{
    public class CountServices : ICountServices
    {
        private readonly AppDatabase _database;

        public CountServices(AppDatabase database)
        {
            _database = database;
        }

        public Task<List<CountModel>> GetFinalyCount()
            => _database.Connection
                .Table<CountModel>()
                .Where(c => c.Status == 1)
                .ToListAsync();

        public Task<CountModel?> GetOpenCount()
            => _database.Connection
                .Table<CountModel>()
                .FirstOrDefaultAsync(c => c.Status == 0);

        

        public Task<int> AddCount(CountModel count)
            => _database.Connection.InsertAsync(count);

        public Task<int> UpdateCount(CountModel count)
            => _database.Connection.UpdateAsync(count);

        public Task<int> Delete(CountModel count)
            => _database.Connection.DeleteAsync(count);
    }
    
}
