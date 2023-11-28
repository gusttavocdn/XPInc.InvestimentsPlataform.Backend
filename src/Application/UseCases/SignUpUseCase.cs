using Application.Dtos.Requests;
using Application.Dtos.Responses;
using Application.Interfaces.Repositories;
using Application.Interfaces.UseCases;
using Domain.Entities.Account;
using Domain.Entities.Client;

namespace Application.UseCases;

public class SignUpUseCase : ISignUpUseCase
{
	private readonly IAccountsRepository _accountRepository;
	private readonly IClientsRepository _clientRepository;

	public SignUpUseCase(IAccountsRepository accountRepository, IClientsRepository clientRepository)
	{
		_accountRepository = accountRepository;
		_clientRepository = clientRepository;
	}

	public async Task<SignUpResponse> ExecuteAsync(SignUpRequest request)
	{
		var client = new Client(request.Name, request.Email, request.Password);
		if (!await _clientRepository.CreateAsync(client))
			return null;

		var account = new Account(client.Id, 1000, 0, 1000);
		if (!await _accountRepository.CreateAsync(account))
			return null;
		return new SignUpResponse();
	}
}
