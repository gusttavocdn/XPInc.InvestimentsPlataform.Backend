using Domain.Entities.Account;

namespace Application.Interfaces.Repositories;

public interface IAccountsRepository
{
	Task<bool> CreateAsync(Account account);
}
