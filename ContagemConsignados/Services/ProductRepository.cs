using ContagemConsignados.Mvvm.Model;
using ContagemConsignados.Services.Interface;
using SQLite;

namespace ContagemConsignados.Services
{

    internal class ProductRepository : IProductRepository
    {
        private SQLiteAsyncConnection _dbConnection;
        public async Task InitializeAsync()
        {
            await SetUpDb();
        }
        private async Task SetUpDb()
        {
            if(_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.
                GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ProductsAccounted.db3");

                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<Product>();
            }
        }
        public async Task<List<Product>> GetAllAsync()
        {
            return await _dbConnection.Table<Product>().ToListAsync();
        }
        public async Task<Product> GetByIdAsync(int id)
        {
            return await _dbConnection.Table<Product>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> AddProduct(Product product)
        {
            return await _dbConnection.InsertAsync(product);
        }
        
        public async Task<int> UpdteProduct(Product product)
        {
            return await _dbConnection.UpdateAsync(product);
        }

        public async Task<int> Delete(Product product)
        {
           return await _dbConnection.DeleteAsync(product);
        }
    }
}
