using Application.Dtos.Requests.Account;
using Application.Dtos.Responses.Account;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Interfaces.UseCases;

namespace Application.UseCases.Account;

public class GetAccountBalanceUseCase : IGetAccountBalanceUseCase
{
	private readonly IJwtProvider _jwtProvider;
	private readonly IClientsRepository _clientsRepository;

	public GetAccountBalanceUseCase(IJwtProvider jwtProvider, IClientsRepository clientsRepository)
	{
		_jwtProvider = jwtProvider;
		_clientsRepository = clientsRepository;
	}

	public async Task<GetBalanceResponse> ExecuteAsync
	(
		GetBalanceRequest request, string token,
		CancellationToken cancellationToken = default
	)
	{
		var tokenInfo = _jwtProvider.DecodeToken(token);
		var balance = await _clientsRepository.GetAccountBalanceAsync(tokenInfo.Email);
		return new GetBalanceResponse(balance);
	}
}