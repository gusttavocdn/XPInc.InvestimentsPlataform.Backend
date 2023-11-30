using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IPortfolioRepository
{
	Task<bool> UpsertPortfolioAsync(Asset asset, int purchasedQuantity, string accountId);
}
