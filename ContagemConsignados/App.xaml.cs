using ContagemConsignados.Services.Interface;
using ContagemConsignados.Mvvm.View;

namespace ContagemConsignados
{
    public partial class App : Application
    {
        private readonly IAuthService _authService;

        public App(IAuthService authService)
        {
            InitializeComponent();
            Application.Current!.UserAppTheme = AppTheme.Light;
            _authService = authService;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window =  new Window(new ContentPage());
            InitializeApp(window);
            return window;
        }

        private async void InitializeApp(Window window)
        {
            bool logado = await _authService.IsUserLoggedAsync();

            if (logado)
            {
                window.Page = new AppShell();
            }
            else
            {
                window.Page = new NavigationPage(new LoginPage(_authService));
            }
        }
    }
}