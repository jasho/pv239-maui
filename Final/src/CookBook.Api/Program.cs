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

const string IngredientsGroupName = "Ingredients";

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
    .WithTags(IngredientsGroupName)
    .WithName("GetAll");

app.MapGet("/api/ingredients/{id:guid}", (Guid id) =>
{
    return new IngredientDetailModel(id, "Vejce", "Prostě vejce", "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/Chicken_egg_2009-06-04.jpg/428px-Chicken_egg_2009-06-04.jpg");
})
    .WithTags(IngredientsGroupName)
    .WithName("GetById");

app.MapPost("/api/ingredients", (IngredientDetailModel ingredient) =>
{
    return Guid.NewGuid();
})
    .WithTags(IngredientsGroupName)
    .WithName("Create");

app.MapPut("/api/ingredients", (IngredientDetailModel ingredient) =>
    {
        return Results.Ok();
    })
    .WithTags(IngredientsGroupName)
    .WithName("Update");

app.MapDelete("/api/ingredients/{id:guid}", (Guid id) =>
    {
        return Results.Ok();
    })
    .WithTags(IngredientsGroupName)
    .WithName("Delete");

app.Run();