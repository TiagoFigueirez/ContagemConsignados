using ContagemConsignados.Mvvm.Model;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using ContagemConsignados.Mvvm.View;

namespace ContagemConsignados.Mvvm.ViewModel
{
    public class NewCountViewModel : ObservableObject
    {
        private readonly INavigation? _navigation;
        public ICommand? OpenCameraCommand { get; }
        public ICommand? DeleteProduct {  get; }
        public ObservableCollection<Product>? Products { get; set; } = new();
        public NewCountViewModel() : this(Application.Current.MainPage.Navigation) { }
        public NewCountViewModel(INavigation? navigation)
        {
            _navigation = navigation;

            OpenCameraCommand = new Command(async ()=>
            {
                var scannerVm = new ScannerViewModel();
                var scannerPage = new ScannerView() {BindingContext = scannerVm };

                scannerVm.CodeRead += async (s, code) =>
                {
                    var dataProducts = code.Split(' ');

                    var existingProduct = Products.FirstOrDefault(p => p.Codigo == dataProducts[0] && p.Lote == dataProducts[1]);

                    if(existingProduct is null)
                    {
                        var Product = new Product()
                        {
                            Codigo = dataProducts[0],
                            Lote = dataProducts[1],
                            DataValidade = dataProducts[2],
                            Quantidade = 1

                        };

                        Products.Add(Product);
                    }
                    else
                    {
                        existingProduct.Quantidade++;
                    }

                        await _navigation!.PopAsync();
                };

                await _navigation!.PushAsync(scannerPage);
            });
        }

    }
}
