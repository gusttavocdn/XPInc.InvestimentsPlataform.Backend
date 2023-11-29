using Application.Dtos.Requests;
using Application.Interfaces.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/v1/assets")]
[Authorize]
public class AssetsController : ControllerBase
{
	private readonly IGetAllAssetsUseCase _getAllAssetsUseCase;
	private readonly IGetAssetBySymbolUseCase _getAssetBySymbolUseCase;

	public AssetsController
		(IGetAllAssetsUseCase getAllAssetsUseCase, IGetAssetBySymbolUseCase getAssetBySymbolUseCase)
	{
		_getAllAssetsUseCase = getAllAssetsUseCase;
		_getAssetBySymbolUseCase = getAssetBySymbolUseCase;
	}

	[HttpGet]
	public async Task<IActionResult> GetAllAssets()
	{
		var output = await _getAllAssetsUseCase.ExecuteAsync(new GetAllAssetsRequest());
		return output is null ? BadRequest() : Ok(output);
	}

	[HttpGet("{symbol}")]
	public async Task<IActionResult> GetAssetBySymbol(string symbol)
	{
		var output = await _getAssetBySymbolUseCase.ExecuteAsync(symbol);
		return output is null ? BadRequest() : Ok(output);
	}
}
