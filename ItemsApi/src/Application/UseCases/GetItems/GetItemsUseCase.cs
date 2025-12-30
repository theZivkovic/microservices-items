namespace Application.UseCases.GetItems;

using Domain;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

public interface IGetItemsUseCase : IUseCase<PagedListRequestDto, IPagedList<Item>> { }
public class GetItemsUseCase(IItemsRepository ItemsRepository, IPagedListFactory<Item> ItemListFactory) : IGetItemsUseCase
{
    public async Task<Result<IPagedList<Item>>> Execute(PagedListRequestDto input)
    {
        var pagedList = await ItemListFactory.CreateAsync(
            ItemsRepository.GetItemsQuery().Value!,
            input.PageNumber,
            input.PageSize
        );

        return Result<IPagedList<Item>>.Success(pagedList);
    }
}