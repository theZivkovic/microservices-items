using Domain.Interfaces;

public class UuidIdGenerator : IIdGenerator<string>
{
    public string NewId()
    {
        return Guid.NewGuid().ToString();
    }
}