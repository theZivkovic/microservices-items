
namespace Domain.Interfaces;

public interface IPagedListFactory<T>
{
    Task<IPagedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize);
}