using ContagemConsignados.AppDataBase;
using ContagemConsignados.Mvvm.View;
using ContagemConsignados.Mvvm.ViewModel;
using ContagemConsignados.Services;
using ContagemConsignados.Services.Interface;
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
            builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();
            builder.Services.AddSingleton<IProductServices, ProductServices>();
            builder.Services.AddTransient<NewCountViewModel>();
            builder.Services.AddSingleton<AppDatabase>(s =>
            {
                var dbPath = Path.Combine(
                    FileSystem.AppDataDirectory,
                    "AccountProducts.db3");

                return new AppDatabase(dbPath);
            });

            return builder.Build();
        }
    }
}
