using Application.Dtos.Requests;
using Application.Dtos.Requests.Assets;
using Application.Exceptions;
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
		try
		{
			var output = await _getAllAssetsUseCase.ExecuteAsync(new GetAllAssetsRequest());
			return Ok(output);
		}
		catch (Exception)
		{
			return StatusCode
			(
				StatusCodes.Status500InternalServerError, new { Message = "Internal Server Error" }
			);
		}
	}

	[HttpGet("{symbol}")]
	public async Task<IActionResult> GetAssetBySymbol(string symbol)
	{
		try
		{
			var output = await _getAssetBySymbolUseCase.ExecuteAsync(symbol);
			return output is null ? BadRequest() : Ok(output);
		}
		catch (HttpStatusException ex)
		{
			return StatusCode(ex.StatusCode, new { ex.Message });
		}
		catch (Exception)
		{
			return StatusCode
			(
				StatusCodes.Status500InternalServerError, new { Message = "Internal Server Error" }
			);
		}
	}
}