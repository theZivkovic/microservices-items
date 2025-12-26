namespace Presentation.Utils;

using Domain;

public static class ResultUtils
{
    public static IResult ToResponse<T>(this Result<T> result)
    {
        return result switch
        {
            { IsSuccess: true } => Results.Ok(result.Value!),
            { IsFailure: true } => Results.BadRequest(result.Error),
            _ => throw new NotImplementedException(),
        };
    }
}