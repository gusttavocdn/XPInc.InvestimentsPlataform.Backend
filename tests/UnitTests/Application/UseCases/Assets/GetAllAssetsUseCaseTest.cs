using Application.Dtos.Requests.Assets;
using Application.Dtos.Responses.Assets;
using Application.Interfaces.Repositories;
using Application.Interfaces.UseCases;
using Application.UseCases.Assets;
using AutoBogus;
using FluentAssertions;
using Moq;

namespace UnitTests.Application.UseCases.Assets;

public class GetAllAssetsUseCaseTest
{
	private readonly Mock<IAssetsRepository> _assetsRepositoryMock;
	private readonly IGetAllAssetsUseCase _useCase;

	public GetAllAssetsUseCaseTest()
	{
		_assetsRepositoryMock = new Mock<IAssetsRepository>();
		_useCase = new GetAllAssetsUseCase(_assetsRepositoryMock.Object);
	}

	[Fact(DisplayName = "Should get all assets")]
	public async Task ShouldGetAllAssets()
	{
		var input = new AutoFaker<GetAllAssetsRequest>().Generate();
		var expectedAssets = new AutoFaker<GetAllAssetsResponse>().Generate();

		_assetsRepositoryMock.Setup(x => x.GetAllAsync(CancellationToken.None))
			.ReturnsAsync(expectedAssets.Assets);

		var output = await _useCase.ExecuteAsync(input);

		output.Assets.Should().BeEquivalentTo(expectedAssets.Assets);
	}

	[Fact(DisplayName = "Should throw if repository throws")]
	public async Task ShouldThrowIfRepositoryThrows()
	{
		var input = new AutoFaker<GetAllAssetsRequest>().Generate();

		_assetsRepositoryMock.Setup(x => x.GetAllAsync(CancellationToken.None))
			.ThrowsAsync(new Exception("Error"));

		Func<Task> act = async () => await _useCase.ExecuteAsync(input);

		await act.Should().ThrowAsync<Exception>();
	}
}
