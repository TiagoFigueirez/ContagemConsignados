using CommunityToolkit.Mvvm.ComponentModel;
using ContagemConsignados.Mvvm.View;
using ContagemConsignados.Services.Interface;
using ContagemConsignados.Utilities;

namespace ContagemConsignados.Mvvm.ViewModel
{
    public partial class SignatureViewModel : ObservableObject
    {
        private readonly IUnitOfWork _wof;
        public SignatureDrawable SignatureDrawableConferente { get; } = new();
        public SignatureDrawable SignatureDrawableCliente { get; } = new();

        [ObservableProperty]
        private string? assinaturaConferente;

        [ObservableProperty]
        private string? assinaturaCliente;

        public SignatureViewModel(IUnitOfWork wof)
        {
            _wof = wof;
        }

        public async Task SaveSignatureAsync()
        {
            if(AssinaturaCliente == null || AssinaturaConferente == null) 
                return;

           var atualityCount = await  _wof.CountServices.GetOpenCount();

            if(atualityCount is null) 
                return;

            atualityCount.SignatureConferente = AssinaturaConferente.ToString() ;
            atualityCount.SignatureCliente = AssinaturaCliente.ToString();

            atualityCount.Status = 1;

            _wof.CountServices.UpdateCount(atualityCount);

            bool confirm = await Shell.Current.DisplayAlert(
                "Confirmação",
                "Contagem Finalizada, Deseja já gerar o relatorio?",
                "Sim",
                "Não");

            if (confirm)
            {
                await Shell.Current.GoToAsync(
                $"{nameof(finishCountToReport)}?countId={atualityCount.Id}"
                );
            }
            else
            {
                await Shell.Current.GoToAsync("..");
            }
        }
    }
}
