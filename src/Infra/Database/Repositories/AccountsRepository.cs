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

	public async Task UpdateAccountBalanceWhenAssetIsPurchasedAsync
		(string accountId, Asset asset, int purchasedQuantity)
	{
		var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == accountId);
		if (account is null)
			throw new Exception();

		var newBalance = account.Balance - asset.Price * purchasedQuantity;
		account.Balance = newBalance;
		_context.Accounts.Update(account);

		await _context.InvestmentsHistory.AddAsync
		(
			new InvestmentsHistoryModel
			{
				AccountId = accountId,
				InvestmentType = "Buy",
				Price = asset.Price,
				Quantity = purchasedQuantity,
				AssetId = asset.Id
			}
		);

		await _context.SaveChangesAsync();
	}
}
