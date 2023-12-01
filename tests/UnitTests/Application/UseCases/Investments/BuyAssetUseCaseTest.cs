using Application.Dtos.Requests.Investments;
using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Interfaces.UseCases;
using Application.UseCases.Investments;
using AutoBogus;
using Domain.Entities;
using FluentAssertions;
using Moq;

namespace UnitTests.Application.UseCases.Investments;

public class BuyAssetUseCaseTest
{
	private readonly Mock<IJwtProvider> _jwtProviderMock;
	private readonly Mock<IClientsRepository> _clientsRepositoryMock;
	private readonly Mock<IAssetsRepository> _assetsRepositoryMock;
	private readonly Mock<IPortfolioRepository> _portfolioRepositoryMock;

	private readonly IBuyAssetUseCase _useCase;
	private readonly TokenInfo _tokenInfo;

	public BuyAssetUseCaseTest()
	{
		_clientsRepositoryMock = new Mock<IClientsRepository>();
		_jwtProviderMock = new Mock<IJwtProvider>();
		_assetsRepositoryMock = new Mock<IAssetsRepository>();
		_portfolioRepositoryMock = new Mock<IPortfolioRepository>();

		_useCase = new BuyAssetUseCase
		(
			_jwtProviderMock.Object, _clientsRepositoryMock.Object, _assetsRepositoryMock.Object,
			_portfolioRepositoryMock.Object
		);

		_tokenInfo = new TokenInfo
		{
			Name = "Test",
			Email = "test@test.com"
		};
	}

	[Fact(DisplayName = "Should buy asset")]
	public async Task ShouldBuyAsset()
	{
		var request = new BuyAssetRequest
		{
			AssetSymbol = "TEST",
			Quantity = 2
		};
		var expectedAsset = new AutoFaker<Asset>()
			.RuleFor(x => x.Symbol, request.AssetSymbol)
			.Generate();
		var clientAccount = new Domain.Entities.Account
			(Guid.NewGuid().ToString(), expectedAsset.Price * request.Quantity * 2);

		_jwtProviderMock.Setup(x => x.DecodeToken(It.IsAny<string>()))
			.Returns(_tokenInfo);

		_assetsRepositoryMock.Setup
				(x => x.GetBySymbolAsync(request.AssetSymbol, CancellationToken.None))
			.ReturnsAsync(expectedAsset);

		_clientsRepositoryMock.Setup(x => x.GetClientAccountAsync(_tokenInfo.Email))
			.ReturnsAsync(clientAccount);

		var output = await _useCase.ExecuteAsync(request, string.Empty);

		output.Quantity.Should().Be(request.Quantity);
		output.Symbol.Should().Be(request.AssetSymbol);
		output.UnitPrice.Should().Be(expectedAsset.Price);
		output.TotalPrice.Should().Be(expectedAsset.Price * request.Quantity);
	}

	[Fact(DisplayName = "Should throw if asset not found")]
	public async Task ShouldThrowIfNotFound()
	{
		var request = new AutoFaker<BuyAssetRequest>().Generate();

		_jwtProviderMock.Setup(x => x.DecodeToken(It.IsAny<string>()))
			.Returns(_tokenInfo);

		_assetsRepositoryMock.Setup
				(x => x.GetBySymbolAsync(request.AssetSymbol, CancellationToken.None))
			.ReturnsAsync((Asset)null);

		Func<Task> act = async () => await _useCase.ExecuteAsync(request, string.Empty);

		await act.Should().ThrowAsync<HttpStatusException>()
			.WithMessage("Asset not found");
	}

	[Fact(DisplayName = "Should throw if insufficient balance")]
	public async Task ShouldThrowIfInsufficientBalance()
	{
		var request = new AutoFaker<BuyAssetRequest>().Generate();
		var asset = new AutoFaker<Asset>().Generate();
		var clientAccount = new Domain.Entities.Account(Guid.NewGuid().ToString(), 0);

		_jwtProviderMock.Setup(x => x.DecodeToken(It.IsAny<string>()))
			.Returns(_tokenInfo);

		_clientsRepositoryMock.Setup(x => x.GetClientAccountAsync(_tokenInfo.Email))
			.ReturnsAsync(clientAccount);

		_assetsRepositoryMock.Setup
				(x => x.GetBySymbolAsync(request.AssetSymbol, CancellationToken.None))
			.ReturnsAsync(asset);

		Func<Task> act = async () => await _useCase.ExecuteAsync(request, string.Empty);

		await act.Should().ThrowAsync<HttpStatusException>()
			.WithMessage("Insufficient Balance");
	}

	[Fact(DisplayName = "Should throw if repository throws")]
	public async Task ShouldThrowIfRepositoryThrows()
	{
		var request = new AutoFaker<BuyAssetRequest>().Generate();

		_jwtProviderMock.Setup(x => x.DecodeToken(It.IsAny<string>()))
			.Returns(_tokenInfo);

		_assetsRepositoryMock.Setup
				(x => x.GetBySymbolAsync(request.AssetSymbol, CancellationToken.None))
			.ThrowsAsync(new Exception("Error"));

		Func<Task> act = async () => await _useCase.ExecuteAsync(request, string.Empty);

		await act.Should().ThrowAsync<Exception>();
	}
}
