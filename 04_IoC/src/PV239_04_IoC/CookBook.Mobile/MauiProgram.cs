using CommunityToolkit.Maui;
using CookBook.Mobile.Clients;
using CookBook.Mobile.Resources.Fonts;
using CookBook.Mobile.ViewModels;
using CookBook.Mobile.Views;
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
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("FontAwesome-Solid.ttf", Fonts.FontAwesome);
                fonts.AddFont("Montserrat-Bold.ttf", Fonts.Bold);
                fonts.AddFont("Montserrat-Medium.ttf", Fonts.Medium);
                fonts.AddFont("Montserrat-Regular.ttf", Fonts.Regular);
            });

        ConfigureClients(builder.Services);
        ConfigureViewModels(builder.Services);
        ConfigureViews(builder.Services);

#if DEBUG
        builder.Logging.AddDebug();
#endif

        RegisterRoutes();
        return builder.Build();
    }

    private static void ConfigureClients(IServiceCollection services)
    {
        services.AddSingleton<IIngredientsClient, IngredientsClient>();
        services.AddSingleton<IRecipesClient, RecipesClient>();
    }

    private static void ConfigureViewModels(IServiceCollection services)
    {
        services.Scan(selector => selector
            .FromAssemblyOf<App>()
            .AddClasses(filter => filter.AssignableTo<ViewModelBase>())
            .AsSelfWithInterfaces()
            .WithTransientLifetime());
    }

    private static void ConfigureViews(IServiceCollection services)
    {
        services.Scan(selector => selector
            .FromAssemblyOf<App>()
            .AddClasses(filter => filter.AssignableTo<ContentPageBase>())
            .AsSelf()
            .WithTransientLifetime());
    }

    private static void RegisterRoutes()
    {
        Routing.RegisterRoute("ingredients/detail", typeof(IngredientDetailView));
    }
}
