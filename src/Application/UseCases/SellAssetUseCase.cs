using Application.Dtos.Requests;
using Application.Dtos.Responses;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Interfaces.UseCases;

namespace Application.UseCases;

public class SellAssetUseCase : ISellAssetUseCase
{
	private readonly IJwtProvider _jwtProvider;
	private readonly IClientsRepository _clientsRepository;
	private readonly IAssetsRepository _assetsRepository;
	private readonly IPortfolioRepository _portfolioRepository;

	public SellAssetUseCase
	(
		IJwtProvider jwtProvider, IClientsRepository clientsRepository,
		IAssetsRepository assetsRepository,
		IPortfolioRepository portfolioRepository
	)
	{
		_jwtProvider = jwtProvider;
		_clientsRepository = clientsRepository;
		_assetsRepository = assetsRepository;
		_portfolioRepository = portfolioRepository;
	}

	public async Task<SellAssetResponse> ExecuteAsync
		(SellAssetRequest request, CancellationToken cancellationToken = default)
	{
		var tokenInfo = _jwtProvider.DecodeToken(request.userToken);
		var clientAccount = await _clientsRepository.GetClientAccountAsync(tokenInfo.Email);
		var assetToSell = await _assetsRepository.GetBySymbolAsync
			(request.AssetSymbol, cancellationToken);
		if (assetToSell is null)
			return null;
		await _portfolioRepository.DecrementPortfolioAsync
			(assetToSell, request.Quantity, clientAccount!.Id);
		return new SellAssetResponse
		(
			request.AssetSymbol, request.Quantity, assetToSell.Price,
			assetToSell.Price * request.Quantity
		);
	}
}
