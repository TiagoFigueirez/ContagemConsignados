using ContagemConsignados.Mvvm.Model;
using ContagemConsignados.Mvvm.View;
using ContagemConsignados.Services.Interface;
using System.Runtime.CompilerServices;

namespace ContagemConsignados
{
    public partial class App : Application
    {
        private readonly IAuthService _authService;
        private readonly IUserSessionService _userSessionService;

        public App(IAuthService authService, IUserSessionService userSessionService)
        {
            InitializeComponent();
            Application.Current!.UserAppTheme = AppTheme.Light;
            _authService = authService;
            _userSessionService = userSessionService;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window =  new Window(new ContentPage());
            InitializeApp(window);
            return window;
        }

        private async void InitializeApp(Window window)
        {
            bool isLogged = await _authService.IsUserLoggedAsync();
           

            if (isLogged)
            {
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

                window.Page = new AppShell();
            }
            else
            {
                window.Page = new NavigationPage(new LoginPage(_authService, _userSessionService));
            }
        }
    }
}