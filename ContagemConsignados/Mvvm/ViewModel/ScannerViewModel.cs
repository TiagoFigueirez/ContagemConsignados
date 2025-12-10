using CommunityToolkit.Mvvm.ComponentModel;

namespace ContagemConsignados.Mvvm.ViewModel
{
    public class ScannerViewModel : ObservableObject
    {
        public EventHandler<string>? CodeRead { get; set; }

        public void OnBarCodeDetected(string code)
        {
            CodeRead?.Invoke(this, code);
        }
    }
}
