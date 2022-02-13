using AutoMapper;
using CookBook.Api;
using CookBook.Api.Facades;
using CookBook.Api.Repositories;
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

builder.Services.AddSingleton<IStorage, Storage>();
builder.Services.AddSingleton<IIngredientRepository, IngredientRepository>();
builder.Services.AddSingleton<IIngredientFacade, IngredientFacade>();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

var mapper = app.Services.GetRequiredService<IMapper>();
mapper.ConfigurationProvider.AssertConfigurationIsValid();

app.UseOpenApi();
app.UseSwaggerUi3(settings =>
{
    settings.DocumentTitle = "CookBook Swagger UI";
    settings.SwaggerRoutes.Add(new SwaggerUi3Route("CookBook API", "/swagger/cookbook-api/swagger.json"));
});
app.UseHttpsRedirection();

const string IngredientsBasePath = "/api/ingredients";
const string IngredientBaseName = "Ingredient";
var IngredientsTag = $"{IngredientBaseName}s";

app.MapGet($"{IngredientsBasePath}", (IIngredientFacade ingredientFacade) => ingredientFacade.GetAll())
    .WithTags(IngredientsTag)
    .WithName($"Get{IngredientBaseName}sAll");

app.MapGet($"{IngredientsBasePath}/{{id:guid}}", (Guid id, IIngredientFacade ingredientFacade) => ingredientFacade.GetById(id))
    .WithTags(IngredientsTag)
    .WithName($"Get{IngredientBaseName}ById");

app.MapPost($"{IngredientsBasePath}", (IngredientDetailModel ingredient, IIngredientFacade ingredientFacade) => ingredientFacade.Create(ingredient))
    .WithTags(IngredientsTag)
    .WithName($"Create{IngredientBaseName}");

app.MapPut($"{IngredientsBasePath}", (IngredientDetailModel ingredient, IIngredientFacade ingredientFacade) => ingredientFacade.Update(ingredient))
    .WithTags(IngredientsTag)
    .WithName($"Update{IngredientBaseName}");

app.MapDelete($"{IngredientsBasePath}/{{id:guid}}", (Guid id, IIngredientFacade ingredientFacade) => ingredientFacade.Delete(id))
    .WithTags(IngredientsTag)
    .WithName($"Delete{IngredientBaseName}");

const string RecipeBaseName = "Recipe";
var RecipesTag = $"{RecipeBaseName}s";

app.MapGet("/api/recipes", () =>
    {
        return new List<RecipeListModel>
        {
            new(Guid.NewGuid(), "Míchaná vajíčka", FoodType.MainDish, "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ef/Scrambled_eggs-01.jpg/320px-Scrambled_eggs-01.jpg"),
            new(Guid.NewGuid(), "Vykostěné kuře s citronem a bylinkami", FoodType.MainDish, "https://d3lp4xedbqa8a5.cloudfront.net/s3/digital-cougar-assets/Gt/2021/04/07/19090/web_Chicken-and-Artichokes.jpg"),
            new(Guid.NewGuid(), "Rajčatová polévka", FoodType.Soup, "https://upload.wikimedia.org/wikipedia/commons/thumb/4/46/Cream_of_tomato_soup.jpg/800px-Cream_of_tomato_soup.jpg"),
            new(Guid.NewGuid(), "Muffin", FoodType.Dessert, "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8a/Muffin_NIH.jpg/733px-Muffin_NIH.jpg")
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

app.MapGet("/", async http => http.Response.Redirect("/swagger", false));

app.Run();