using GaleriaMauiApp.Pages;
using Microsoft.Extensions.Logging;

namespace GaleriaMauiApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddTransient<GaleriaPage>();

            // dotnet add package Microsoft.Extensions.Http
            builder.Services.AddHttpClient("api", client => client.BaseAddress = new Uri("https://10.0.2.2:5000"))
                  .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
                  {
                      ServerCertificateCustomValidationCallback = (message, cert, chain, error) => true

                      //ServerCertificateCustomValidationCallback = (_, __, ___, ____) => true
                  });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
