using Application.Dtos.Responses.Account;
using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IClientsRepository
{
	Task<bool> CreateAsync(Client client);
	Task<Client?> GetByEmailAsync(string requestEmail);
	Task<Account?> GetClientAccountAsync(string clientEmail);
	Task<GetTransactionsExtractResponse> GetTransactionsExtractAsync(string clientEmail);
}