using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContagemConsignados.Mvvm.Model;
using ContagemConsignados.Mvvm.View;
using ContagemConsignados.Services.Interface;
using System.Collections.ObjectModel;

namespace ContagemConsignados.Mvvm.ViewModel
{
    [QueryProperty(nameof(CountId), "countId")]
    public partial class CountDetailViewModel : ObservableObject
    {
        private readonly IUnitOfWork _wof;

        [ObservableProperty]
        string email;

        [ObservableProperty]
        string observer;

        [ObservableProperty]
        private CountModel count;

        [ObservableProperty]
        private ObservableCollection<Product> products;

        public int CountId { get; set; }
        public CountDetailViewModel(IUnitOfWork wof)
        {
            _wof = wof;
            Products = new ObservableCollection<Product>();
        }

        [RelayCommand]
        public async Task InitializeAsync()
        {
            count = await _wof.CountServices.GetCountById(CountId);
            var products = await _wof.ProductServices.GetByCount(count.Id);

            Products = new ObservableCollection<Product>(products);
        }

        [RelayCommand]
        public async Task UpdateCount()
        {
            if (string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(Observer))
            {
                await Shell.Current.DisplayAlert(
                    "Atenção",
                    "Preencha todos os campos.",
                    "OK");
                return;
            }
            Count.Email = Email;
            Count.Observer = Observer;
           
            await Shell.Current.GoToAsync(nameof(SignaturePage));
        }
    }
}
