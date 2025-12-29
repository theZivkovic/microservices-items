namespace Application.UseCases.CreateItem;

using Domain.Models;
using FluentValidation;

public record CreateItemRequestDto(string title, string body)
{
}


public class CreateItemRequestDtoValidator : AbstractValidator<CreateItemRequestDto>
{
    public CreateItemRequestDtoValidator()
    {
        RuleFor(customer => customer.title).NotEmpty().WithMessage("You must specify a title name.");
        RuleFor(customer => customer.title).Length(2, 255).WithMessage("Title name must be between 2 and 255 characters.");
        RuleFor(customer => customer.body).NotEmpty().WithMessage("You must specify a body.");
        RuleFor(customer => customer.body).Length(2, 255).WithMessage("Body must be between 2 and 255 characters.");
    }
}
