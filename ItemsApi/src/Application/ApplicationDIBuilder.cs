using Application.UseCases.CreateItem;
using Application.UseCases.GetItems;

namespace Presentation;

public static class ApplicationDIBuilder
{
    public static void Build(WebApplicationBuilder builder)
    {

        builder.Services.AddScoped<ICreateItemUseCase, CreateItemUseCase>();
        builder.Services.AddScoped<IGetItemsUseCase, GetItemsUseCase>();
        builder.Services.AddScoped<IDeleteItemUseCase, DeleteItemUseCase>();
    }
}