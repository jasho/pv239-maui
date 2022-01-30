using CookBook.Common.Enums;
using CookBook.Common.Models;
using NSwag.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(document =>
{
    document.Title = "CookBook API";
    document.DocumentName = "cookbook-api";
});

var app = builder.Build();

app.UseOpenApi();
app.UseSwaggerUi3(settings =>
{
    settings.DocumentTitle = "CookBook Swagger UI";
    settings.SwaggerRoutes.Add(new SwaggerUi3Route("CookBook API", "/swagger/cookbook-api/swagger.json"));
});
app.UseHttpsRedirection();

const string IngredientBaseName = "Ingredient";
var IngredientsTag = $"{IngredientBaseName}s";

const string RecipeBaseName = "Recipe";
var RecipesTag = $"{RecipeBaseName}s";

app.MapGet("/api/ingredients", () =>
{
    return new List<IngredientListModel>
    {
        new(Guid.NewGuid(), "Vejce",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/Chicken_egg_2009-06-04.jpg/428px-Chicken_egg_2009-06-04.jpg"),
        new(Guid.NewGuid(), "Cibule",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/2/25/Onion_on_White.JPG/480px-Onion_on_White.JPG"),
    };
})
    .WithTags(IngredientsTag)
    .WithName($"Get{IngredientBaseName}sAll");

app.MapGet("/api/ingredients/{id:guid}", (Guid id) =>
{
    return new IngredientDetailModel(id, "Vejce", "Prostě vejce", "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/Chicken_egg_2009-06-04.jpg/428px-Chicken_egg_2009-06-04.jpg");
})
    .WithTags(IngredientsTag)
    .WithName($"Get{IngredientBaseName}ById");

app.MapPost("/api/ingredients", (IngredientDetailModel ingredient) =>
{
    return Guid.NewGuid();
})
    .WithTags(IngredientsTag)
    .WithName($"Create{IngredientBaseName}");

app.MapPut("/api/ingredients", (IngredientDetailModel ingredient) =>
    {
        return Results.Ok();
    })
    .WithTags(IngredientsTag)
    .WithName($"Update{IngredientBaseName}");

app.MapDelete("/api/ingredients/{id:guid}", (Guid id) =>
    {
        return Results.Ok();
    })
    .WithTags(IngredientsTag)
    .WithName($"Delete{IngredientBaseName}");

app.MapGet("/api/recipes", () =>
    {
        return new List<RecipeListModel>
        {
            new(Guid.NewGuid(), "Míchaná vajíčka", new TimeSpan(0, 30, 0), FoodType.MainDish, "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ef/Scrambled_eggs-01.jpg/320px-Scrambled_eggs-01.jpg"),
            new(Guid.NewGuid(), "Vykostěné kuře s citronem a bylinkami", new TimeSpan(1, 0, 0), FoodType.MainDish, "https://d3lp4xedbqa8a5.cloudfront.net/s3/digital-cougar-assets/Gt/2021/04/07/19090/web_Chicken-and-Artichokes.jpg"),
        };
    })
    .WithTags(RecipesTag)
    .WithName($"Get{RecipeBaseName}sAll");

app.MapGet("/api/recipes/{id:guid}", (Guid id) =>
    {
        return new RecipeDetailModel(id, "Míchaná vajíčka", "Prostě míchaná vajíčka.", new TimeSpan(0, 30, 0), FoodType.MainDish,
            new List<RecipeDetailIngredientModel>
            {
                new (Guid.NewGuid(), 5, Unit.Pieces, new(Guid.NewGuid(), "Vejce",
                    "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/Chicken_egg_2009-06-04.jpg/428px-Chicken_egg_2009-06-04.jpg"))
            },
            "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ef/Scrambled_eggs-01.jpg/320px-Scrambled_eggs-01.jpg");
    })
    .WithTags(RecipesTag)
    .WithName($"Get{RecipeBaseName}ById");

app.MapPost("/api/recipes", (RecipeDetailModel recipe) =>
    {
        return Guid.NewGuid();
    })
    .WithTags(RecipesTag)
    .WithName($"Create{RecipeBaseName}");

app.MapPut("/api/recipes", (RecipeDetailModel recipe) =>
    {
        return Results.Ok();
    })
    .WithTags(RecipesTag)
    .WithName($"Update{RecipeBaseName}");

app.MapDelete("/api/recipes/{id:guid}", (Guid id) =>
    {
        return Results.Ok();
    })
    .WithTags(RecipesTag)
    .WithName($"Delete{RecipeBaseName}");

app.Run();