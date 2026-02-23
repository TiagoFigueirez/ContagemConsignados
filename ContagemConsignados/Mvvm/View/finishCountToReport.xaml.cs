using ContagemConsignados.Mvvm.ViewModel;

namespace ContagemConsignados.Mvvm.View;

public partial class finishCountToReport : ContentPage
{
	public finishCountToReport(FinishCountToReportViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is FinishCountToReportViewModel vm)
            await vm.InitializeAsync();
    }
}