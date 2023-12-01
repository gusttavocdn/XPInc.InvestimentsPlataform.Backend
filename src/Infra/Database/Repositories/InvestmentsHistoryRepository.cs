using Application.Interfaces.Repositories;
using Domain.Entities;
using Infra.Database.Context;
using Infra.Database.models;

namespace Infra.Database.Repositories;

public class InvestmentsHistoryRepository : IInvestmentsHistoryRepository
{
	private readonly ApplicationDbContext _context;

	public InvestmentsHistoryRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<bool> AddTransaction
		(Asset asset, int purchasedQuantity, string accountId)
	{
		var transaction = new InvestmentsHistoryModel
		{
			AccountId = accountId,
			InvestmentType = "Buy",
			Price = asset.Price,
			Quantity = purchasedQuantity,
			AssetId = asset.Id
		};

		await _context.InvestmentsHistory.AddAsync(transaction);
		await _context.SaveChangesAsync();
		return true;
	}
}