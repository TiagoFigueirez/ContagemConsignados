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

    private async void Button_Clicked(object sender, EventArgs e)
	{
        var scannerVm = new ScannerViewModel();
        var scannerPage = new ScannerView
        {
            BindingContext = scannerVm
        };

        scannerVm.CodeRead += async (s, code) =>
        {
            await _vm.AddOrIncrementProductAsync(code);
            await Navigation.PopAsync();
        };

        await Navigation.PushAsync(scannerPage);
    }
}