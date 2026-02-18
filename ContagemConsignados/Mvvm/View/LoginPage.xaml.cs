using ContagemConsignados.Mvvm.Model;
using ContagemConsignados.Services.Interface;
using Microsoft.Identity.Client;

namespace ContagemConsignados.Mvvm.View;

public partial class LoginPage : ContentPage
{
	private readonly IAuthService _authService;

    private readonly string[] _scopes = new[]
        {
            "User.Read"
        };
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

          //var  _pca = PublicClientApplicationBuilder
          //         .Create(MsalModel.ClientId)
          //         .WithAuthority(MsalModel.Authority)
          //         .WithRedirectUri($"msal{MsalModel.ClientId}://auth")
          //         .Build();

            var result = await _authService.LoginAsync();

            if (!string.IsNullOrEmpty(result.AccessToken))
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Application.Current.MainPage = new AppShell();
                });
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