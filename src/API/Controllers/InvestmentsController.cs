using Application.Dtos.Requests;
using Application.Interfaces.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
[Route("api/v1/investments")]
public class InvestmentsController : ControllerBase
{
	private readonly IBuyAssetUseCase _buyAssetUse;

	public InvestmentsController(IBuyAssetUseCase buyAssetUse)
	{
		_buyAssetUse = buyAssetUse;
	}

	[HttpPost]
	[Route("buy")]
	public async Task<IActionResult> BuyAssets
		([FromBody] BuyAssetRequest request)
	{
		var authorizationHeader = Request.Headers["Authorization"].ToString();
		request.userToken = authorizationHeader["Bearer ".Length..].Trim();

		var output = await _buyAssetUse.ExecuteAsync(request);
		return Ok(output);
	}
}
