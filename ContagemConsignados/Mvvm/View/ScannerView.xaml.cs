using ContagemConsignados.Mvvm.ViewModel;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace ContagemConsignados.Mvvm.View;

public partial class ScannerView : ContentPage
{
	public ScannerView()
	{
		InitializeComponent();

        cameraView.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormats.OneDimensional,
            AutoRotate = true,
            Multiple = true
        };
    }

    private void cameraView_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
		var codigo = e.Results?.FirstOrDefault()?.Value;

		if(string.IsNullOrEmpty(codigo) )
		   return;

			MainThread.BeginInvokeOnMainThread(async () =>
			{
				(BindingContext as ScannerViewModel)?.OnBarCodeDetected(codigo);
			});

    }
}