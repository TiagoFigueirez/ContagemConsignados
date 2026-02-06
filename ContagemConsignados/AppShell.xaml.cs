using ContagemConsignados.Mvvm.View;

namespace ContagemConsignados
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NewCount), typeof(NewCount));
            Routing.RegisterRoute(nameof(CountDetail), typeof(CountDetail));
            Routing.RegisterRoute(nameof(PreviousCount), typeof(PreviousCount));
            Routing.RegisterRoute(nameof(SignaturePage), typeof(SignaturePage));
        }
    }
}
