using ContagemConsignados.AppDataBase;
using ContagemConsignados.Mvvm.Model;
using ContagemConsignados.Services.Interface;

namespace ContagemConsignados.Services
{

    public class ProductServices : IProductServices
    {
        private readonly AppDatabase _database;

        public ProductServices(AppDatabase database)
        {
            _database = database;
        }

        public Task<List<Product>> GetByCount(int countId)
            => _database.Connection
                .Table<Product>()
                .Where(p => p.CountId == countId)
                .ToListAsync();

        public Task Add(Product product)
            => _database.Connection.InsertAsync(product);

        public Task Update(Product product)
            => _database.Connection.UpdateAsync(product);

        public Task Delete(Product product)
            => _database.Connection.DeleteAsync(product);
    }
}
