using Microsoft.Extensions.Logging;
using CookBook.Maui.Pages;

namespace CookBook.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("FontAwesome-Solid.ttf", CookBook.Maui.Resources.Fonts.Fonts.FontAwesome);
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        Routing.RegisterRoute("ingredients/detail", typeof(IngredientDetailPage));
        return builder.Build();
    }
}