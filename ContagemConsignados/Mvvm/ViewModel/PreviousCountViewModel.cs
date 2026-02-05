using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContagemConsignados.Mvvm.Model;
using ContagemConsignados.Mvvm.View;
using ContagemConsignados.Services.Interface;
using System.Collections.ObjectModel;

namespace ContagemConsignados.Mvvm.ViewModel
{
    public partial class PreviousCountViewModel : ObservableObject
    {
        private readonly IUnitOfWork _wof;

        [ObservableProperty]
        private ObservableCollection<CountModel> counts;

        public PreviousCountViewModel(IUnitOfWork wof)
        {
            _wof = wof;
            counts = new ObservableCollection<CountModel>();
        }

        [RelayCommand]
        public async Task InitializeAsync()
        {
            var counts = await _wof.CountServices.GetFinalyCount();

            Counts = new ObservableCollection<CountModel>(counts);
        }

        [RelayCommand]
        public async Task OpenCount(CountModel count)
        {
            if (count == null)
                return;

            await Shell.Current.GoToAsync(
                $"{nameof(CountDetail)}?countId={count.Id}"
                );
        }
    }
}
