using ContagemConsignados.Mvvm.Model;

namespace ContagemConsignados.Services.Interface
{
    public interface ICountServices
    {
        Task<CountModel?> GetOpenCount();
        Task<List<CountModel>> GetFinalyCount();
        Task<CountModel?> GetCountById(int id);
        Task<int> AddCount(CountModel count);
        Task<int> UpdateCount(CountModel count);
        Task<int> Delete(CountModel count);

    }
}
