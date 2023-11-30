using Application.Dtos.Requests;
using Application.Interfaces.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
[Route("api/v1/investments")]
public class InvestmentsController : ControllerBase
{
	private readonly IBuyAssetUseCase _buyAssetUseCase;
	private readonly ISellAssetUseCase _sellAssetUseCase;

	public InvestmentsController(IBuyAssetUseCase buyAssetUse, ISellAssetUseCase sellAssetUse)
	{
		_buyAssetUseCase = buyAssetUse;
		_sellAssetUseCase = sellAssetUse;
	}

	[HttpPost]
	[Route("buy")]
	public async Task<IActionResult> BuyAssets
		([FromBody] BuyAssetRequest request)
	{
		var authorizationHeader = Request.Headers["Authorization"].ToString();
		request.userToken = authorizationHeader["Bearer ".Length..].Trim();

		var output = await _buyAssetUseCase.ExecuteAsync(request);
		return Ok(output);
	}

	[HttpPost]
	[Route("sell")]
	public async Task<IActionResult> SellAssets([FromBody] SellAssetRequest request)
	{
		var authorizationHeader = Request.Headers["Authorization"].ToString();
		request.userToken = authorizationHeader["Bearer ".Length..].Trim();

		var output = await _sellAssetUseCase.ExecuteAsync(request);
		return Ok(output);
	}
}
