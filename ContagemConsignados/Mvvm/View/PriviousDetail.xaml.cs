using ContagemConsignados.Mvvm.ViewModel;

namespace ContagemConsignados.Mvvm.View;

public partial class PriviousDetail : ContentPage
{
	public PriviousDetail(PriviousDetailViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is PriviousDetailViewModel vm)
            await vm.InitializeAsync();
    }
}