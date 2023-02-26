using CookBook.Mobile.Resources.Fonts;
using CookBook.Mobile.Views.Ingredient;
using Microsoft.Extensions.Logging;

namespace CookBook.Mobile;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
                fonts.AddFont("FontAwesome-Solid.ttf", Fonts.FontAwesome);
                fonts.AddFont("Montserrat-Bold.ttf", Fonts.Bold);
                fonts.AddFont("Montserrat-Medium.ttf", Fonts.Medium);
                fonts.AddFont("Montserrat-Regular.ttf", Fonts.Regular);
			});

        builder.Services.AddTransient<IngredientDetailView>();
        Routing.RegisterRoute("ingredients/detail", typeof(IngredientDetailView));

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
