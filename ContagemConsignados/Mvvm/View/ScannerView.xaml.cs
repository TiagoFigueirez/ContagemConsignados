using ContagemConsignados.Mvvm.ViewModel;

namespace ContagemConsignados.Mvvm.View;

public partial class ScannerView : ContentPage
{
	public ScannerView()
	{
		InitializeComponent();
	}

    private void cameraView_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
		var codigo = e.Results?.FirstOrDefault()?.Value;

		if(!string.IsNullOrEmpty(codigo) )
		{
			MainThread.BeginInvokeOnMainThread(async () =>
			{
				(BindingContext as ScannerViewModel)?.OnBarCodeDetected(codigo);

				await Navigation.PopAsync();
			});
		}
    }
}