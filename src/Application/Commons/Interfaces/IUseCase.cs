namespace Application.Commons;

public interface IUseCase<in TRequest, TResponse>
{
	Task<TResponse> ExecuteAsync
		(TRequest request, CancellationToken cancellationToken = default);
}