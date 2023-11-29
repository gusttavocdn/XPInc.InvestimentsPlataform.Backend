using System.Globalization;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infra.Database.Context;
using Infra.Database.models;

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
			InvestmentsValue = account.InvestmentsValue,
			TotalAssets = account.TotalAssets,
			CreatedAt = DateTime.Now.ToString(CultureInfo.InvariantCulture),
			UpdatedAt = DateTime.Now.ToString(CultureInfo.InvariantCulture)
		};

		if (await _context.Accounts.AddAsync(accountModel) is null)
			return false;
		await _context.SaveChangesAsync();
		return true;
	}
}
