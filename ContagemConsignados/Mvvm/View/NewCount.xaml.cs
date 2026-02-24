using ContagemConsignados.Mvvm.ViewModel;
using System.Threading.Tasks;

namespace ContagemConsignados.Mvvm.View;

public partial class NewCount : ContentPage
{
	private readonly NewCountViewModel _vm;
	
	public NewCount(NewCountViewModel vm)
	{
		InitializeComponent();
        _vm = vm;
        BindingContext = _vm;
	}

    protected override async void OnAppearing()
    {
		base.OnAppearing();
        await _vm.InitializeAsync();
    }


}