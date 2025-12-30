using Application.UseCases.GetItems;
using Domain.Constants;

namespace Presentation;

public class PaginationMiddleware
{
    private readonly RequestDelegate _next;

    public PaginationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        int pageNumber = PaginationConstants.DefaultPageNumber;
        int pageSize = PaginationConstants.DefaultPageSize;

        if (context.Request.Headers.TryGetValue("X-Page-Number", out var pageNumberHeader))
        {
            if (int.TryParse(pageNumberHeader, out int value))
            {
                pageNumber = value;
            }
        }

        if (context.Request.Headers.TryGetValue("X-Page-Size", out var pageSizeHeader))
        {
            if (int.TryParse(pageSizeHeader, out int value))
            {
                pageSize = value;
            }
        }

        var pagedRequest = new PagedListRequestDto(pageNumber, pageSize);

        context.Items["PagedListRequest"] = pagedRequest;
        await _next(context);
    }
}