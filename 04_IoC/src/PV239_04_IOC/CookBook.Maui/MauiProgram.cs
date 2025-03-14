using CommunityToolkit.Maui;
using CookBook.Maui.Clients;
using CookBook.Maui.Clients.Interfaces;
using CookBook.Maui.Pages;
using CookBook.Maui.Pages.Recipe;
using CookBook.Maui.ViewModels;
using CookBook.Maui.ViewModels.Ingredient;
using CookBook.Maui.ViewModels.Recipe;
using Microsoft.Extensions.Logging;

namespace CookBook.Maui;

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
                fonts.AddFont("FontAwesome-Solid.ttf", CookBook.Maui.Resources.Fonts.Fonts.FontAwesome);
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
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
        services.AddTransient<IngredientListViewModel>();
        services.AddTransient<IngredientDetailViewModel>();
        services.AddTransient<RecipeListViewModel>();
        services.AddTransient<RecipeDetailViewModel>();
        services.AddTransient<SettingsViewModel>();
    }

    private static void ConfigureViews(IServiceCollection services)
    {
        services.AddTransient<IngredientListPage>();
        services.AddTransient<IngredientDetailPage>();
        services.AddTransient<RecipeListPage>();
        services.AddTransient<RecipeDetailPage>();
        services.AddTransient<SettingsPage>();
    }

    private static void RegisterRoutes()
    {
        Routing.RegisterRoute("ingredients/detail", typeof(IngredientDetailPage));
        Routing.RegisterRoute("recipes/detail", typeof(RecipeDetailPage));
    }
}