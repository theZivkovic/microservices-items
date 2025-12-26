
using Domain;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.Postgres.Models;

namespace Infrastructure.Postgres.Repositories;


public class ItemsRepository(ItemsDbContext dbContext) : IItemsRepository
{

    public async Task<Result<Item>> AddItem(Item item)
    {
        dbContext.Items.Add(ItemModel.FromDomain(item));
        await dbContext.SaveChangesAsync();
        return Result<Item>.Success(item);
    }

    public async Task<Result<Item>> DeleteItem(string itemId)
    {
        var foundItem = await dbContext.Items.FindAsync(itemId);

        if (foundItem == null)
        {
            return Result<Item>.Failure(ErrorCode.ItemNotFound);
        }
        dbContext.Items.Remove(foundItem);
        await dbContext.SaveChangesAsync();
        return Result<Item>.Success(foundItem.ToDomain().Value!);
    }

    public Result<IQueryable<Item>> GetItemsQuery()
    {
        return Result<IQueryable<Item>>.Success(dbContext
            .Items
            .OrderByDescending(x => x.CreatedAt)
            .Select(x => x.ToDomain().Value!)
        );
    }
}