using ContagemConsignados.Mvvm.Model;
using ContagemConsignados.Services.Interface;
using Microsoft.Identity.Client;

namespace ContagemConsignados.Mvvm.View;

public partial class LoginPage : ContentPage
{
	private readonly IAuthService _authService;
    private readonly IUserSessionService _userSession;

    public LoginPage(IAuthService authService, IUserSessionService userSession)
    {
        InitializeComponent();
        _authService = authService;
        _userSession = userSession;
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        try
        {
            LoadingIndicator.IsVisible = true;
            LoadingIndicator.IsRunning = true;

            var result = await _authService.LoginAsync();

            var userfilial = result.ClaimsPrincipal.FindFirst("name")?.Value;
            var userFilial = userfilial.Split(" - ");

            var User = new UserSession
            {
                Name = userFilial[0],
                Email = result.ClaimsPrincipal.FindFirst("preferred_username")?.Value,
                ObjectId = result.ClaimsPrincipal.FindFirst("oid")?.Value,
                IsAuthenticated = true,
                Filal = userFilial[1]
            };

            _userSession.SetUser(User);

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