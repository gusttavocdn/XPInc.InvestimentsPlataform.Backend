using Application.Dtos.Requests;
using Application.Dtos.Responses;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Interfaces.UseCases;

namespace Application.UseCases;

public class SignInUseCase : ISignInUseCase
{
	private readonly IClientsRepository _clientsRepository;
	private readonly IPasswordManager _passwordManager;

	public SignInUseCase(IClientsRepository clientsRepository, IPasswordManager passwordManager)
	{
		_clientsRepository = clientsRepository;
		_passwordManager = passwordManager;
	}

	public async Task<SignInResponse> ExecuteAsync
		(SignInRequest request, CancellationToken cancellationToken = default)
	{
		var client = await _clientsRepository.GetByEmailAsync(request.Email);
		if (client is null || !IsPasswordValid(request.Password, client.Password))
			return null;
		return new SignInResponse("Token");
	}

	private bool IsPasswordValid(string password, string hash)
	{
		return _passwordManager.Verify(password, hash);
	}
}
