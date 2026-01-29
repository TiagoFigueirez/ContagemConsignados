using ContagemConsignados.Mvvm.ViewModel;
using ZXing.Net.Maui;

namespace ContagemConsignados.Mvvm.View;

public partial class ScannerView : ContentPage
{
    private bool _scanning = false;

    public ScannerView()
    {
        InitializeComponent();

        cameraView.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormats.OneDimensional,
            AutoRotate = true,
            Multiple = false
        };
    }

    private void cameraView_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        if (_scanning) return;

        _scanning = true;   

        var codigo = e.Results?.FirstOrDefault()?.Value;

        if (string.IsNullOrEmpty(codigo))
        {
            return;
        }


        MainThread.BeginInvokeOnMainThread(async () =>
        {
            (BindingContext as ScannerViewModel)?.OnBarCodeDetected(codigo);
        });

    }
}