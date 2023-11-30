using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IAccountsRepository
{
	Task<bool> CreateAsync(Account account);
	Task<bool> UpdateAccountBalanceAsync(string accountId, decimal newBalance);
}