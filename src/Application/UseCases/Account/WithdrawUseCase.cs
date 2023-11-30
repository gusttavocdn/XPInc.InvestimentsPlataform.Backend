using Application.Dtos.Requests.Account;
using Application.Dtos.Responses.Account;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Interfaces.UseCases;

namespace Application.UseCases.Account;

public class WithdrawUseCase : IWithdrawUseCase
{
	private readonly IJwtProvider _jwtProvider;
	private readonly IClientsRepository _clientsRepository;

	public WithdrawUseCase(IClientsRepository clientsRepository, IJwtProvider jwtProvider)
	{
		_clientsRepository = clientsRepository;
		_jwtProvider = jwtProvider;
	}

	public async Task<WithdrawResponse> ExecuteAsync
		(WithdrawRequest request, string token, CancellationToken cancellationToken = default)
	{
		var tokenInfo = _jwtProvider.DecodeToken(token);
		await _clientsRepository.WithdrawAsync(tokenInfo.Email, request.Value);
		return new WithdrawResponse();
	}
}
