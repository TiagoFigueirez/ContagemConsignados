using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using ContagemConsignados.Messeges;

namespace ContagemConsignados.Mvvm.ViewModel
{
    public class ScannerViewModel : ObservableObject
    {

        public void OnBarCodeDetected(string code)
        {
            WeakReferenceMessenger.Default.Send(new CodeReadMessage(code));
        }
    }
}
