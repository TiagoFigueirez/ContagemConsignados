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
            Routing.RegisterRoute(nameof(finishCountToReport), typeof(finishCountToReport));
            Routing.RegisterRoute(nameof(ScannerView), typeof(ScannerView));
        }
    }
}
