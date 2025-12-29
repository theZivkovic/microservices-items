namespace Application.UseCases.CreateItem;

using Domain;
using Domain.Enums;
using Domain.Interfaces.Clients;
using Domain.Interfaces.Repositories;
using Domain.Models;

public interface IDeleteItemUseCase : IUseCase<string, Item> { }
public class DeleteItemUseCase(
    IItemsRepository ItemsRepository,
    ILogger<DeleteItemUseCase> logger,
    IAuditLogClient auditLogClient) : IDeleteItemUseCase
{

    public async Task<Result<Item>> Execute(string itemId)
    {
        var deleteItemResult = await ItemsRepository.DeleteItem(itemId);

        if (deleteItemResult.IsFailure)
        {
            return deleteItemResult;
        }

        await auditLogClient.AddItemEvent(AuditLogEventType.ItemDeleted, deleteItemResult.Value!);

        logger.LogInformation("Item {itemId} deleted", itemId);
        return deleteItemResult;
    }
}