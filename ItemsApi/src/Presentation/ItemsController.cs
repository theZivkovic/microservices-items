using System.Text.Json;
using Application.UseCases.CreateItem;
using Application.UseCases.GetItems;
using Presentation.Utils;
using SharpGrip.FluentValidation.AutoValidation.Endpoints.Extensions;

namespace Presentation;

public static class ItemsController
{
    public static void BuildEndpoints(WebApplication app)
    {
        var allEndpoints = app.MapGroup("/").AddFluentValidationAutoValidation();

        allEndpoints.MapGet("/", () =>
        {
            return Results.Ok("");
        });
        allEndpoints.MapGet("/api/items", async (IGetItemsUseCase getItemsUseCase) =>
        {
            return (await getItemsUseCase.Execute(new object())).ToResponse();
        }).WithName("Get Items");

        allEndpoints.MapPost("/api/items", async (CreateItemRequestDto request, ICreateItemUseCase createItemUseCase) =>
        {
            return (await createItemUseCase.Execute(request)).ToResponse();
        }).WithName("Create Item");

        allEndpoints.MapDelete("/api/items/{itemId}", async (string itemId, IDeleteItemUseCase deleteItemUseCase) =>
        {
            return (await deleteItemUseCase.Execute(itemId)).ToResponse();
        }).WithName("Delete Item");
    }
}