using ContagemConsignados.Mvvm.Model;
using SQLite;

namespace ContagemConsignados.AppDataBase
{
    public class AppDatabase
    {
        private readonly SQLiteAsyncConnection _connection;
        public SQLiteAsyncConnection Connection => _connection;

        public AppDatabase(string dbPath)
        {
            _connection = new SQLiteAsyncConnection(dbPath);

            _connection.CreateTableAsync<CountModel>().Wait();
            _connection.CreateTableAsync<Product>().Wait();
        }       
    }
}
