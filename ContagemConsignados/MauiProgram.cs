using ContagemConsignados.Services.Interface;
using ContagemConsignados.Services;
using Microsoft.Extensions.Logging;
using ZXing.Net.Maui.Controls;

namespace ContagemConsignados
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseBarcodeReader()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                ;

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<IProductRepository, ProductServices>();
            return builder.Build();
        }
    }
}
