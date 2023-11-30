using Application.Commons.Interfaces;
using Application.Dtos.Requests.Account;
using Application.Dtos.Responses.Account;

namespace Application.Interfaces.UseCases;

public interface IGetTransactionsUseCase : IAuthenticatedUseCases<GetTransactionsExtractRequest,
	GetTransactionsExtractResponse>
{
}
