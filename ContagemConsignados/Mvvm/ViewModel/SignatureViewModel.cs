using CommunityToolkit.Mvvm.ComponentModel;
using ContagemConsignados.Utilities;

namespace ContagemConsignados.Mvvm.ViewModel
{
    public partial class SignatureViewModel : ObservableObject
    {
        public SignatureDrawable SignatureDrawableConferente { get; } = new();
        public SignatureDrawable SignatureDrawableCliente { get; } = new();

        [ObservableProperty]
        private byte[]? assinaturaConferente;

        [ObservableProperty]
        private byte[]? assinaturaCliente;

        public void ClearSignatures()
        {
            SignatureDrawableConferente.Clear();
            SignatureDrawableCliente.Clear();
        }
    }
}
