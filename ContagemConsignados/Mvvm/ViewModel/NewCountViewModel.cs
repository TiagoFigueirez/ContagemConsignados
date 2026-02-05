using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContagemConsignados.Mvvm.Model;
using ContagemConsignados.Mvvm.View;
using ContagemConsignados.Services.Interface;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ContagemConsignados.Mvvm.ViewModel
{
    public partial class NewCountViewModel : ObservableObject
    {
        private readonly IUnitOfWork _wof;
        private CountModel _countAtual;

        public ICommand OpenCameraCommand { get; }

        [ObservableProperty]
        private ObservableCollection<Product> products;

        public NewCountViewModel(IUnitOfWork wof)
        {
            _wof = wof;
            Products = new ObservableCollection<Product>();
            OpenCameraCommand = new Command(async () => await OpenCamera());
            
        }

        [RelayCommand]
        public async Task InitializeAsync()
        {
            _countAtual = await _wof.CountServices.GetOpenCount();

            if(_countAtual == null)
            {
                _countAtual = new CountModel
                {
                    DateCount = DateTime.Now,
                    Status = 0
                };

                await _wof.CountServices.AddCount(_countAtual);
            }
            var products = await _wof.ProductServices.GetByCount(_countAtual.Id);
            Products = new ObservableCollection<Product>(products);

            
        }

        private async Task OpenCamera()
        {
            var scannerVm = new ScannerViewModel();
            var scannerPage = new ScannerView
            {
                BindingContext = scannerVm
            };

            scannerVm.CodeRead += async (s, code) =>
            {
                await AddOrIncrementProductAsync(code);
                await Shell.Current.Navigation.PopAsync();
            };

            await Shell.Current.Navigation.PushAsync(scannerPage);
        }

        public async Task AddOrIncrementProductAsync(string code)
        {
            var data = code.Split(' ');

            var exsting = Products.FirstOrDefault(p => p.Codigo == data[0] && p.Lote == data[1]);

            if(exsting is null)
            {
                var product = new Product
                {
                    Codigo = data[0],
                    Lote = data[1],
                    DataValidade = data[2],
                    Quantidade = 1,
                    CountId = _countAtual.Id
                };

                await _wof.ProductServices.Add(product);
                Products.Add(product);
            }
            else
            {
                exsting.Quantidade++;
                await _wof.ProductServices.Update(exsting);
            }
        }

        [RelayCommand]
        private void DeleteProduct(Product product)
        {
            if (Products.Contains(product))
            {
                Products.Remove(product);
                _wof.ProductServices.Delete(product);
            }
        }

        [RelayCommand]
        public async Task OpenCount()
        {
            if (_countAtual == null)
                return;

            await Shell.Current.GoToAsync(
                $"{nameof(CountDetail)}?countId={_countAtual.Id}"
                );
        }
    }

}

