namespace Domain;

public enum ErrorCode
{
    ItemIdInvalid,
    ItemTitleInvalid,
    ItemBodyInvalid,
    ItemCreatedAtInvalid,
    ItemNotFound,
}

public class Error
{
    public Error(ErrorCode code)
    {
        Code = code;
    }

    public ErrorCode Code { get; set; }
}