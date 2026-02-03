using ContagemConsignados.Mvvm.Model;

namespace ContagemConsignados.Services.Interface
{
    public interface IProductServices
    {
        Task<List<Product>> GetByCount(int countId);
        Task Add(Product product);
        Task Update(Product product);
        Task Delete(Product product);
    }
}
