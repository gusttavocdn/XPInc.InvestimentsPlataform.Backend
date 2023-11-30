using Application.Interfaces.Repositories;
using Domain.Entities;
using Infra.Database.Context;
using Infra.Database.models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.Repositories;

public class PortfolioRepository : IPortfolioRepository
{
	private readonly ApplicationDbContext _context;

	public PortfolioRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<bool> UpsertPortfolioAsync
		(Asset asset, int purchasedQuantity, string accountId)
	{
		var portfolio = await _context.Portfolios.FirstOrDefaultAsync
		(
			p => p.AccountId == accountId && p.AssetId == asset.Id
		);

		if (portfolio is null)
			return await InsertPortfolioAsync(asset, purchasedQuantity, accountId);
		return await UpdatePortfolioAsync(portfolio, asset, purchasedQuantity);
	}

	private async Task<bool> UpdatePortfolioAsync
		(PortfolioModel portfolio, Asset asset, int purchasedQuantity)
	{
		portfolio.Quantity += purchasedQuantity;
		portfolio.AcquisitionValue += purchasedQuantity * asset.Price;
		// portfolio.AveragePurchasePrice = portfolio.AcquisitionValue / portfolio.Quantity;
		// portfolio.CurrentValue = portfolio.Quantity * portfolio.AveragePurchasePrice;
		// portfolio.ProfitabilityValue = portfolio.CurrentValue - portfolio.AcquisitionValue;
		// portfolio.ProfitabilityPercentage = portfolio.ProfitabilityValue / portfolio.AcquisitionValue;
		_context.Portfolios.Update(portfolio);
		return await _context.SaveChangesAsync() > 0;
	}

	private async Task<bool> InsertPortfolioAsync
		(Asset asset, int purchasedQuantity, string accountId)
	{
		var portfolio = new PortfolioModel
		{
			AccountId = accountId,
			AssetId = asset.Id,
			Quantity = purchasedQuantity,
			Symbol = asset.Symbol,
			ProfitabilityPercentage = 0,
			ProfitabilityValue = 0,
			AveragePurchasePrice = asset.Price,
			CurrentValue = asset.Price,
			AcquisitionValue = asset.Price * purchasedQuantity,
			CreatedAt = DateTime.Now.ToString(),
			UpdatedAt = DateTime.Now.ToString()
		};

		await _context.Portfolios.AddAsync(portfolio);
		return await _context.SaveChangesAsync() > 0;
	}
}
