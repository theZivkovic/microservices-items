
namespace Domain;

public interface IPagedList<T>
{
    List<T> CurrentPageItems { get; set; }
    int CurrentPage { get; set; }
    int PageSize { get; set; }
    int TotalCount { get; set; }
    int TotalPages { get; }
    bool IsPreviousPageExists { get; }
    bool IsNextPageExists { get; }
}

public class PagedList<T> : IPagedList<T>
{
    public PagedList(IEnumerable<T> currentPage, int count, int pageNumber, int pageSize)
    {
        CurrentPage = pageNumber;
        PageSize = pageSize;
        TotalCount = count;
        CurrentPageItems = [.. currentPage];
    }
    public List<T> CurrentPageItems { get; set; }

    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public bool IsPreviousPageExists => CurrentPage > 1;
    public bool IsNextPageExists => CurrentPage < TotalPages;
}