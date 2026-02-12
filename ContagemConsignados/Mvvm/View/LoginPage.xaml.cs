using ContagemConsignados.Services.Interface;

namespace ContagemConsignados.Mvvm.View;

public partial class LoginPage : ContentPage
{
	private readonly IAuthService _authService;
    public LoginPage(IAuthService authService)
    {
        InitializeComponent();
        _authService = authService;
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        try
        {
            LoadingIndicator.IsVisible = true;
            LoadingIndicator.IsRunning = true;

            var response = _authService.LoginAsync();

            if (!string.IsNullOrEmpty(response.Result.AccessToken))
            {
                Application.Current.MainPage = new AppShell();
            }


        }catch(Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "Ok");
        }
        finally
        {
            LoadingIndicator.IsVisible = false;
            LoadingIndicator.IsRunning = false;
        }
    }
}