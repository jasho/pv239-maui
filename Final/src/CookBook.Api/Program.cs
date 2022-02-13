using AutoMapper;
using CookBook.Api;
using CookBook.Api.Facades;
using CookBook.Api.Repositories;
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
builder.Services.AddSingleton<IRecipeRepository, RecipeRepository>();
builder.Services.AddSingleton<IRecipeFacade, RecipeFacade>();

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


const string RecipeBasePath = "/api/recipes";
const string RecipeBaseName = "Recipe";
var RecipesTag = $"{RecipeBaseName}s";

app.MapGet($"{RecipeBasePath}", (IRecipeFacade recipeFacade) => recipeFacade.GetAll())
    .WithTags(RecipesTag)
    .WithName($"Get{RecipeBaseName}sAll");

app.MapGet($"{RecipeBasePath}/{{id:guid}}", (Guid id, IRecipeFacade recipeFacade) => recipeFacade.GetById(id))
    .WithTags(RecipesTag)
    .WithName($"Get{RecipeBaseName}ById");

app.MapPost($"{RecipeBasePath}", (RecipeDetailModel recipe, IRecipeFacade recipeFacade) => recipeFacade.Create(recipe))
    .WithTags(RecipesTag)
    .WithName($"Create{RecipeBaseName}");

app.MapPut($"{RecipeBasePath}", (RecipeDetailModel recipe, IRecipeFacade recipeFacade) => recipeFacade.Update(recipe))
    .WithTags(RecipesTag)
    .WithName($"Update{RecipeBaseName}");

app.MapDelete($"{RecipeBasePath}/{{id:guid}}", (Guid id, IRecipeFacade recipeFacade) => recipeFacade.Delete(id))
    .WithTags(RecipesTag)
    .WithName($"Delete{RecipeBaseName}");

app.MapGet("/", async http => http.Response.Redirect("/swagger", false));

app.Run();