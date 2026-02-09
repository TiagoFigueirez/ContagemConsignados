using ContagemConsignados.Mvvm.ViewModel;
using ContagemConsignados.Services.Interface;
using ContagemConsignados.Utilities;

namespace ContagemConsignados.Mvvm.View;

public partial class SignaturePage : ContentPage
{
	private readonly SignatureViewModel _vm;
    public SignaturePage(SignatureViewModel vm)
	{
		InitializeComponent();
        _vm = vm;
		BindingContext = _vm;

		AddTouch(SegnatureConferente, _vm.SignatureDrawableConferente);
		AddTouch(SegnatureCliente, _vm.SignatureDrawableCliente);
	}

    private void AddTouch(GraphicsView view, SignatureDrawable drawable)
	{
		view.StartInteraction += (_, e) =>
		{
			drawable.Start(e.Touches[0]);
			view.Invalidate();
		};

        view.DragInteraction += (_, e) =>
        {
            drawable.Move(e.Touches[0]);
            view.Invalidate();
        };

        view.EndInteraction += (_, _) =>
        {
            drawable.End();
        };
    }

	private async void OnSaveClicked(object sender, EventArgs e)
	{
		var imgConf = await SegnatureConferente.CaptureAsync();
		var imgCli = await SegnatureCliente.CaptureAsync();

        if (imgCli == null || imgConf 
            == null)
        {
            await DisplayAlert("Erro", "As duas assinaturas são obrigatórias.", "OK");
            return;
        }

        var respBytes = await ImageHelper.ToPngBase64Async(imgCli);
        var confBytes = await ImageHelper.ToPngBase64Async(imgConf);

        _vm.AssinaturaCliente = respBytes;
        _vm.AssinaturaConferente = confBytes;

        await _vm.SaveSignatureAsync();


        
    }

}