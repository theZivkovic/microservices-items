namespace Domain.Interfaces;

public interface IIdGenerator<T>
{
    public T NewId();
}