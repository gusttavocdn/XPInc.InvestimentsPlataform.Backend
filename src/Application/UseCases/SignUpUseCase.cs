using Application.Dtos.Requests;
using Application.Dtos.Responses;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Interfaces.UseCases;
using Domain.Entities;

namespace Application.UseCases;

public class SignUpUseCase : ISignUpUseCase
{
	private readonly IAccountsRepository _accountRepository;
	private readonly IClientsRepository _clientRepository;
	private readonly IPasswordManager _passwordManager;

	public SignUpUseCase
	(
		IAccountsRepository accountRepository, IClientsRepository clientRepository,
		IPasswordManager passwordManager
	)
	{
		_accountRepository = accountRepository;
		_clientRepository = clientRepository;
		_passwordManager = passwordManager;
	}

	public async Task<SignUpResponse> ExecuteAsync
		(SignUpRequest request, CancellationToken cancellationToken = default)
	{
		var newClient = new Client
			(request.Name, request.Email, _passwordManager.Hash(request.Password));
		if (!await _clientRepository.CreateAsync(newClient))
			return null;

		var account = new Domain.Entities.Account(newClient.Id, 0, 0, 0);
		if (!await _accountRepository.CreateAsync(account))
			return null;
		return new SignUpResponse();
	}
}
