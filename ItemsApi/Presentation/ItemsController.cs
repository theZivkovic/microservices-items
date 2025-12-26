using System.Text.Json;
using Application.UseCases.CreateItem;
using Application.UseCases.GetItems;
using Presentation.Utils;

namespace Presentation;

public static class ItemsController
{
    public static void BuildEndpoints(WebApplication app)
    {
        app.MapGet("/", () =>
        {
            return Results.Ok("");
        });
        app.MapGet("/api/items", async (IGetItemsUseCase getItemsUseCase) =>
        {
            return (await getItemsUseCase.Execute(new object())).ToResponse();
        }).WithName("Get Items");

        app.MapPost("/api/items", async (CreateItemRequestDto request, ICreateItemUseCase createItemUseCase) =>
        {
            return (await createItemUseCase.Execute(request)).ToResponse();
        }).WithName("Create Item");
    }
}