using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContagemConsignados.Mvvm.Model;
using ContagemConsignados.Services.Interface;
using System.Collections.ObjectModel;
namespace ContagemConsignados.Mvvm.ViewModel
{
    [QueryProperty(nameof(CountId), "countId")]
    public partial class PriviousDetailViewModel : ObservableObject
    {
        public int CountId { get; set; }

        public ImageSource AssinaturaClienteImage =>
                           string.IsNullOrEmpty(Count?.SignatureCliente)
                            ? null : ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(Count.SignatureCliente)));

        public ImageSource AssinaturaConferenteImage =>
                            string.IsNullOrEmpty(Count?.SignatureConferente)
                             ? null : ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(Count.SignatureConferente)));

        [ObservableProperty]
        private CountModel count;

        [ObservableProperty]
        private ObservableCollection<Product> products;

        private readonly IUnitOfWork _wof;

        public PriviousDetailViewModel(IUnitOfWork wof)
        {
            _wof = wof;
        }
        public async Task InitializeAsync()
        {
            Count = await _wof.CountServices.GetCountById(CountId);
            var products = await _wof.ProductServices.GetByCount(CountId);
            Products = new ObservableCollection<Product>(products);
        }

        [RelayCommand]
        public async Task ToFinishCount()
        {

        }

    }
}
