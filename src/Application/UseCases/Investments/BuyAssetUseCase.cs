using Application.Dtos.Requests;
using Application.Dtos.Responses;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Interfaces.UseCases;

namespace Application.UseCases;

public class BuyAssetUseCase : IBuyAssetUseCase
{
	private readonly IJwtProvider _jwtProvider;
	private readonly IClientsRepository _clientsRepository;
	private readonly IAssetsRepository _assetsRepository;
	private readonly IAccountsRepository _accountsRepository;
	private readonly IInvestmentsHistoryRepository _investmentsHistoryRepository;
	private readonly IPortfolioRepository _portfolioRepository;

	public BuyAssetUseCase
	(
		IJwtProvider jwtProvider, IClientsRepository clientsRepository,
		IAssetsRepository assetsRepository, IAccountsRepository accountsRepository,
		IInvestmentsHistoryRepository investmentsHistoryRepository,
		IPortfolioRepository portfolioRepository
	)
	{
		_jwtProvider = jwtProvider;
		_clientsRepository = clientsRepository;
		_assetsRepository = assetsRepository;
		_accountsRepository = accountsRepository;
		_investmentsHistoryRepository = investmentsHistoryRepository;
		_portfolioRepository = portfolioRepository;
	}

	public async Task<BuyAssetResponse> ExecuteAsync
		(BuyAssetRequest request, CancellationToken cancellationToken = default)
	{
		var tokenInfo = _jwtProvider.DecodeToken(request.userToken);
		var clientAccount = await _clientsRepository.GetClientAccountAsync(tokenInfo.Email);
		var wantedAsset = await _assetsRepository.GetBySymbolAsync
			(request.AssetSymbol, cancellationToken);
		if (wantedAsset is null)
			return null;
		var wantedAssetsTotalPrice = wantedAsset.Price * request.Quantity;
		if (clientAccount!.Balance < 0 || clientAccount.Balance < wantedAssetsTotalPrice)
			return null;
		var clientAccountNewBalance = clientAccount.Balance - wantedAssetsTotalPrice;
		await _accountsRepository.UpdateAccountBalanceAsync
			(clientAccount.Id, clientAccountNewBalance);
		await _investmentsHistoryRepository.AddTransaction
			(wantedAsset, request.Quantity, clientAccount.Id);
		await _portfolioRepository.IncrementPortfolioAsync
			(wantedAsset, request.Quantity, clientAccount.Id);
		return new BuyAssetResponse
			(wantedAsset.Symbol, request.Quantity, wantedAsset.Price, wantedAssetsTotalPrice);
	}
}