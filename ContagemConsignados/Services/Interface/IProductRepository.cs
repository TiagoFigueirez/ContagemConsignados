using ContagemConsignados.Mvvm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContagemConsignados.Services.Interface
{
    internal interface IProductRepository
    {
        Task InitializeAsync();
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<int> AddProduct(Product product);
        Task<int> UpdteProduct(Product product);
        Task<int> Delete(Product product);
    }
}
