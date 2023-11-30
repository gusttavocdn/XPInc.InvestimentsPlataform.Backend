using Application.Interfaces.Repositories;
using Domain.Entities;
using Infra.Database.Context;
using Infra.Database.models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.Repositories;

public class AccountsRepository : IAccountsRepository
{
	private readonly ApplicationDbContext _context;

	public AccountsRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<bool> CreateAsync(Account account)
	{
		var accountModel = new AccountModel
		{
			Id = account.Id,
			ClientId = account.ClientId,
			Balance = account.Balance,
			UpdatedAt = DateTime.Now
		};

		if (await _context.Accounts.AddAsync(accountModel) is null)
			return false;
		await _context.SaveChangesAsync();
		return true;
	}

	public async Task<bool> UpdateAccountBalanceAsync(string accountId, decimal newBalance)
	{
		var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == accountId);
		if (account == null)
			return false;

		account.Balance = newBalance;
		_context.Accounts.Update(account);
		var updateResult = await _context.SaveChangesAsync();
		return updateResult > 0;
	}
}
