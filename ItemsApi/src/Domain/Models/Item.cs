namespace Domain.Models;

using Domain;

public record Item
{
    public string Id { get; init; }
    public string Title { get; init; }
    public string Body { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }

    private Item(string id, string title, string body, DateTime createdAt, DateTime? updatedAt)
    {
        Id = id;
        Title = title;
        Body = body;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static Result<Item> Create(string id, string title, string body, DateTime createdAt, DateTime? updatedAt)
    {
        var idResult = ValidateId(id);
        if (!idResult.IsSuccess)
        {
            return idResult.MapFailure<Item>();
        }

        var titleResult = ValidateTitle(title);
        if (!titleResult.IsSuccess)
        {
            return titleResult.MapFailure<Item>();
        }

        var bodyResult = ValidateBody(body);
        if (!bodyResult.IsSuccess)
        {
            return bodyResult.MapFailure<Item>();
        }

        var createdAtResult = ValidateCreatedAt(createdAt);
        if (!createdAtResult.IsSuccess)
        {
            return createdAtResult.MapFailure<Item>();
        }

        return Result<Item>.Success(new Item(id, title, body, createdAt, updatedAt));
    }

    private static Result<string> ValidateId(string id)
    {
        return string.IsNullOrWhiteSpace(id)
            ? Result<string>.Failure(ErrorCode.ItemIdInvalid)
            : Result<string>.Success(id);
    }

    private static Result<string> ValidateTitle(string title)
    {
        return string.IsNullOrWhiteSpace(title)
            ? Result<string>.Failure(ErrorCode.ItemTitleInvalid)
            : Result<string>.Success(title);
    }

    private static Result<string> ValidateBody(string body)
    {
        return string.IsNullOrWhiteSpace(body)
            ? Result<string>.Failure(ErrorCode.ItemTitleInvalid)
            : Result<string>.Success(body);
    }

    private static Result<DateTime> ValidateCreatedAt(DateTime createdAt)
    {
        return createdAt < DateTime.UtcNow.AddYears(-100) || createdAt > DateTime.UtcNow.AddYears(100)
            ? Result<DateTime>.Failure(ErrorCode.ItemCreatedAtInvalid)
            : Result<DateTime>.Success(createdAt);
    }
}