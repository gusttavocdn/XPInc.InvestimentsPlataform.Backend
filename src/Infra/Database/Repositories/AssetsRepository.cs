using Application.Interfaces.Repositories;
using Domain.Entities;
using Infra.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.Repositories;

public class AssetsRepository : IAssetsRepository
{
	private readonly ApplicationDbContext _context;

	public AssetsRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<Asset>> GetAllAsync(CancellationToken cancellationToken = default)
	{
		var assetsFromDb = await _context.Assets.ToListAsync(cancellationToken);
		var assets = assetsFromDb.Select
		(
			asset => new Asset
			(
				asset.Id,
				asset.Symbol,
				asset.Name,
				asset.AvailableQuantity,
				asset.Price
			)
		);
		return assets;
	}

	public async Task<Asset?> GetBySymbolAsync
		(string symbol, CancellationToken cancellationToken = default)
	{
		var assetFromDb = await _context.Assets.FirstOrDefaultAsync
		(
			asset => asset.Symbol == symbol,
			cancellationToken
		);

		if (assetFromDb is null)
			return null;

		return new Asset
		(
			assetFromDb.Id, assetFromDb.Symbol, assetFromDb.Name, assetFromDb.AvailableQuantity,
			assetFromDb.Price
		);
	}
}