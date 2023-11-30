using Application.Dtos.Requests.Account;
using Application.Dtos.Responses.Account;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Interfaces.UseCases;

namespace Application.UseCases.Account;

public class DepositUseCase : IDepositUseCase
{
	private readonly IJwtProvider _jwtProvider;
	private readonly IClientsRepository _clientsRepository;

	public DepositUseCase(IJwtProvider jwtProvider, IClientsRepository clientsRepository)
	{
		_jwtProvider = jwtProvider;
		_clientsRepository = clientsRepository;
	}

	public async Task<DepositResponse> ExecuteAsync
		(DepositRequest request, string token, CancellationToken cancellationToken = default)
	{
		var tokenInfo = _jwtProvider.DecodeToken(token);
		await _clientsRepository.DepositAsync(tokenInfo.Email, request.Value);
		return new DepositResponse();
	}
}
