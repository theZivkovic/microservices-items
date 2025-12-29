namespace Application.UseCases.GetItems;

using Domain;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

public interface IGetItemsUseCase : IUseCase<object, List<Item>> { }
public class GetItemsUseCase(IItemsRepository ItemsRepository) : IGetItemsUseCase
{
    public async Task<Result<List<Item>>> Execute(object input)
    {
        return await ItemsRepository.GetItemsQuery().MapAsync(x => x.ToListAsync());
    }
}