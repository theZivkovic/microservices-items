using Domain;

public interface IUseCase<TInput, TOutput>
{
    Task<Result<TOutput>> Execute(TInput input);
}