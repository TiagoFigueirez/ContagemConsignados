using ContagemConsignados.Mvvm.ViewModel;

namespace ContagemConsignados.Mvvm.View;

public partial class NewCount : ContentPage
{
	public NewCount()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

		if(BindingContext == null)
		{
			BindingContext = new NewCountViewModel(Navigation);
		}
    }
}