using System.Data;
using Domain.Constants;
using FluentValidation;

namespace Application.UseCases.GetItems;

public record PagedListRequestDto(
    int PageNumber,
    int PageSize);

public class PagedListRequestDtoValidator : AbstractValidator<PagedListRequestDto>
{
    public PagedListRequestDtoValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThan(0).WithMessage("Page number must be greater than 0.");
        RuleFor(x => x.PageSize)
            .GreaterThan(0).WithMessage("Page size must be greater than 0.")
            .LessThanOrEqualTo(PaginationConstants.MaxPageSize).WithMessage($"Page size must be less than or equal to {PaginationConstants.MaxPageSize}.");
    }
}
