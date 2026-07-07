using Microsoft.Extensions.Logging;
using Microsoft.Maui.Devices;
using OrderManagement.Mobile.Services;

namespace OrderManagement.Mobile
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

            builder.Services.AddSingleton(sp => new HttpClient
            {
                BaseAddress = new Uri(GetApiBaseAddress())
            });
            builder.Services.AddSingleton<ICategoryService, CategoryService>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static string GetApiBaseAddress()
        {
            return DeviceInfo.Platform == DevicePlatform.Android
                ? "https://10.0.2.2:7124/"
                : "https://localhost:7124/";
        }
    }
}
