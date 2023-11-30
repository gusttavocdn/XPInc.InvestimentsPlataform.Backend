using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IInvestmentsHistoryRepository
{
	public Task<bool> AddTransaction(Asset asset, int purchasedQuantity, string accountId);
}