using Application.Dtos.Requests;
using Application.Dtos.Responses;
using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Interfaces.UseCases;
using Microsoft.AspNetCore.Http;

namespace Application.UseCases.Investments;

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
		(SellAssetRequest request, string token, CancellationToken cancellationToken = default)
	{
		var tokenInfo = _jwtProvider.DecodeToken(token);
		var clientAccount = await _clientsRepository.GetClientAccountAsync(tokenInfo.Email);

		var assetToSell = await _assetsRepository.GetBySymbolAsync
			(request.AssetSymbol, cancellationToken);
		if (assetToSell is null)
			throw new HttpStatusException(StatusCodes.Status404NotFound, "Asset not found");

		await _portfolioRepository.DecrementPortfolioAsync
			(assetToSell, request.Quantity, clientAccount!.Id);

		return new SellAssetResponse
		(
			request.AssetSymbol, request.Quantity, assetToSell.Price,
			assetToSell.Price * request.Quantity
		);
	}
}
