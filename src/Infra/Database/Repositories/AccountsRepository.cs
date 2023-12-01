using Application.Exceptions;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infra.Database.Context;
using Infra.Database.models;
using Microsoft.AspNetCore.Http;
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

	public async Task<decimal> GetAccountBalanceAsync(string clientEmail)
	{
		var client = await _context.Clients.Include(c => c.Account).FirstOrDefaultAsync
			(client => client.Email == clientEmail);

		if (client is null)
			throw new HttpStatusException(StatusCodes.Status404NotFound, "Account not found");
		return client.Account!.Balance;
	}

	public async Task<bool> DepositAsync(string clientEmail, decimal amount)
	{
		var client = await _context.Clients.Include(c => c.Account).FirstOrDefaultAsync
			(client => client.Email == clientEmail);

		if (client is null)
			throw new HttpStatusException(StatusCodes.Status404NotFound, "Account not found");

		client.Account!.Balance += amount;
		_context.Accounts.Update(client.Account);

		_context.TransactionHistory.Add
		(
			new TransactionHistoryModel
			{
				AccountId = client.Account.Id,
				Value = amount,
				TransactionType = nameof(TransactionType.Deposit)
			}
		);
		return await _context.SaveChangesAsync() > 0;
	}

	public async Task<bool> WithdrawAsync(string clientEmail, int amount)
	{
		var client = await _context.Clients.Include(c => c.Account).FirstOrDefaultAsync
			(client => client.Email == clientEmail);

		if (client is null)
			throw new HttpStatusException(StatusCodes.Status404NotFound, "Account not found");

		if (client.Account!.Balance < amount)
			throw new HttpStatusException(StatusCodes.Status400BadRequest, "Insufficient funds");

		client.Account!.Balance -= amount;
		_context.Accounts.Update(client.Account);

		_context.TransactionHistory.Add
		(
			new TransactionHistoryModel
			{
				AccountId = client.Account.Id,
				Value = amount,
				TransactionType = nameof(TransactionType.Withdraw)
			}
		);
		return await _context.SaveChangesAsync() > 0;
	}
}
