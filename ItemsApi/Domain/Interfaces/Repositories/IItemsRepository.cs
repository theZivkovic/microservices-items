namespace Domain.Interfaces.Repositories;

using Domain;
using Domain.Models;

public interface IItemsRepository
{
    Task<Result<Item>> AddItem(Item item);
    Task<Result<Item>> DeleteItem(string itemId);
    Result<IQueryable<Item>> GetItemsQuery();

}