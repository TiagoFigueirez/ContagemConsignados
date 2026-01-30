using ContagemConsignados.Mvvm.Model;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using ContagemConsignados.Mvvm.View;
using CommunityToolkit.Mvvm.Input;

namespace ContagemConsignados.Mvvm.ViewModel
{
    public partial class NewCountViewModel : ObservableObject
    {
        private readonly INavigation? _navigation;
        public ObservableCollection<Product> Products { get; set; } = new();
        public NewCountViewModel(INavigation? navigation)
        {
            _navigation = navigation;

        }

        [RelayCommand]
        private async Task OpenCamera()
        {
            var scannerVm = new ScannerViewModel();
            var scannerPage = new ScannerView()
            {
                BindingContext = scannerVm
            };

            scannerVm.CodeRead += async (s, code) =>
            {
                AddOrIncrementProdut(code);
                await _navigation!.PopAsync();
            };

            await _navigation!.PushAsync(scannerPage);

        }

        private void AddOrIncrementProdut(string code)
        {
            var data = code.Split(' ');

            var exsting = Products.FirstOrDefault(p => p.Codigo == data[0] && p.Lote == data[1]);

            if(exsting is null)
            {
                Products.Add(new Product()
                {
                    Codigo = data[0],
                    Lote = data[1],
                    DataValidade = data[2],
                    Quantidade = 1
                });
            }
            else
            {
                exsting.Quantidade++;
            }
        }

        [RelayCommand]
        private void DeleteProduct(Product product)
        {
            if (Products.Contains(product))
            {
                Products.Remove(product);
            }
        }

    }
}
