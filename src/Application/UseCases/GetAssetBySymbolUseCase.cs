using Application.Dtos.Responses;
using Application.Interfaces.Repositories;
using Application.Interfaces.UseCases;

namespace Application.UseCases;

public class GetAssetBySymbolUseCase : IGetAssetBySymbolUseCase
{
	private readonly IAssetsRepository _assetsRepository;

	public GetAssetBySymbolUseCase(IAssetsRepository assetsRepository)
	{
		_assetsRepository = assetsRepository;
	}

	public async Task<GetAssetBySymbolResponse> ExecuteAsync
		(string request, CancellationToken cancellationToken = default)
	{
		var asset = await _assetsRepository.GetBySymbolAsync(request, cancellationToken);
		return new GetAssetBySymbolResponse(asset);
	}
}