using ContagemConsignados.AppDataBase;
using ContagemConsignados.Mvvm.View;
using ContagemConsignados.Mvvm.ViewModel;
using ContagemConsignados.Services;
using ContagemConsignados.Services.Interface;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
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
            builder.Services.AddSingleton<ICountServices, CountServices>();
            builder.Services.AddSingleton<IProductServices, ProductServices>();
            builder.Services.AddSingleton<IAuthService, AuthService>();
            builder.Services.AddSingleton<BiService>();

            builder.Services.AddTransient<IReportServices, ReportServices>();
            builder.Services.AddTransient<NewCountViewModel>();
            builder.Services.AddTransient<CountDetailViewModel>();
            builder.Services.AddTransient<PreviousCountViewModel>();
            builder.Services.AddTransient<FinishCountToReportViewModel>();
            builder.Services.AddTransient<SignatureViewModel>();

            builder.Services.AddSingleton<AppDatabase>(s =>
            {
                var dbPath = Path.Combine(
                    FileSystem.AppDataDirectory,
                    "AccountProducts.db3");

                return new AppDatabase(dbPath);
            });

            builder.ConfigureLifecycleEvents(events =>
            {
#if ANDROID
    events.AddAndroid(android => android
        .OnCreate((activity, _) =>
        {
            Microsoft.Maui.ApplicationModel.Platform.Init(activity, null);
        }));
#endif
            });

            return builder.Build();
        }
    }
}
