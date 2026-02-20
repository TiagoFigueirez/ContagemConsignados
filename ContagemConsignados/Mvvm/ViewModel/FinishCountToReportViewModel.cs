using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContagemConsignados.Mvvm.Model;
using ContagemConsignados.Services.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContagemConsignados.Mvvm.ViewModel
{ 

    [QueryProperty(nameof(CountId), "countId")]
    public partial class FinishCountToReportViewModel : ObservableObject
    {
        private readonly IUnitOfWork _wof;
        [ObservableProperty]
        private ObservableCollection<Product> products;

        [ObservableProperty]
        private CountModel countModel;
        public int CountId { get; set; }

        public FinishCountToReportViewModel(IUnitOfWork wof)
        {
            _wof = wof;
        }

        [RelayCommand]
        public async Task InitializeAsync()
        {

            var Count = _wof.CountServices.GetCountById(CountId);
            
            var products = _wof.ProductServices.GetByCount(CountId);


        }

    }
}
