using Microsoft.Extensions.Logging;
using PV239_02_Design.Pages;

namespace PV239_02_Design
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            Routing.RegisterRoute("main/ingredient-detail", typeof(IngredientDetailPage));
            return builder.Build();
        }
    }
}
