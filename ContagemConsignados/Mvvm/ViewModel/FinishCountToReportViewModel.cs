using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContagemConsignados.Mvvm.Model;
using ContagemConsignados.Services.Interface;
using System.Collections.ObjectModel;


namespace ContagemConsignados.Mvvm.ViewModel
{ 

    [QueryProperty(nameof(CountId), "countId")]
    public partial class FinishCountToReportViewModel : ObservableObject
    {
        public int CountId { get; set; }

        private readonly IUnitOfWork _wof;
        private readonly IEmailServices _emailServices;

        [ObservableProperty]
        private ObservableCollection<Product> products;

        [ObservableProperty]
        private CountModel countModel;

        [ObservableProperty]
        private string hospital;

        public FinishCountToReportViewModel(IUnitOfWork wof, IEmailServices emailServices)
        {
            _wof = wof;
            _emailServices = emailServices;
        }

        [RelayCommand]
        public async Task InitializeAsync()
        {

             CountModel = await _wof.CountServices.GetCountById(CountId);
            
            var products = await _wof.ProductServices.GetByCount(CountId);

            Products = new ObservableCollection<Product>(products);
        }

        [RelayCommand]
        public async Task UpdateCountToRepost()
        {
           CountModel.Hospital = Hospital;
           _wof.CountServices.UpdateCount(CountModel);


            bool emailSucessuful = _emailServices.SubmitEmail("tiago.figueiredo058@gmail.com", CountModel, Products);
        }
    }
}
