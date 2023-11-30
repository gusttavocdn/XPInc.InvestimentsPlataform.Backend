using Application.Dtos.Responses.Account;
using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IClientsRepository
{
	Task<bool> CreateAsync(Client client);
	Task<Client?> GetByEmailAsync(string requestEmail);
	Task<Account?> GetClientAccountAsync(string clientEmail);

	Task<bool> DepositAsync(string clientEmail, decimal amount);
	Task<decimal> GetAccountBalanceAsync(string clientEmail);
	Task<bool> WithdrawAsync(string clientEmail, int amount);

	Task<GetTransactionsExtractResponse> GetTransactionsExtractAsync(string clientEmail);
}
