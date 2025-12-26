namespace Application.UseCases.CreateItem;

using Domain;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Interfaces.Clients;
using Domain.Interfaces.Repositories;
using Domain.Models;

public interface ICreateItemUseCase : IUseCase<CreateItemRequestDto, Item> { }
public class CreateItemUseCase(
    IItemsRepository ItemsRepository,
    IIdGenerator<string> idGenerator,
    IAuditLogClient auditLogClient) : ICreateItemUseCase
{
    public async Task<Result<Item>> Execute(CreateItemRequestDto input)
    {
        var itemResult = Item.Create(idGenerator.NewId(), input.title, input.body, DateTime.UtcNow, null);

        if (itemResult.IsFailure)
        {
            return itemResult;
        }

        var addItemResult = await ItemsRepository.AddItem(itemResult.Value!);

        if (addItemResult.IsFailure)
        {
            return addItemResult;
        }

        await auditLogClient.AddItemEvent(AuditLogEventType.ItemCreated, addItemResult.Value!);

        return addItemResult;
    }
}