using ContagemConsignados.Mvvm.ViewModel;

namespace ContagemConsignados.Mvvm.View;

public partial class PreviousCount : ContentPage
{
	private readonly PreviousCountViewModel _vm;
	public PreviousCount(PreviousCountViewModel vm)
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