using Application.Dtos.Requests;
using Application.Exceptions;
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
		try
		{
			if (ModelState.IsValid is false)
				return BadRequest(ModelState);

			var authorizationHeader = Request.Headers["Authorization"].ToString();
			var token = authorizationHeader["Bearer ".Length..].Trim();

			var output = await _buyAssetUseCase.ExecuteAsync(request, token);
			return Ok(output);
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

	[HttpPost]
	[Route("sell")]
	public async Task<IActionResult> SellAssets([FromBody] SellAssetRequest request)
	{
		try
		{
			var authorizationHeader = Request.Headers["Authorization"].ToString();
			var token = authorizationHeader["Bearer ".Length..].Trim();

			var output = await _sellAssetUseCase.ExecuteAsync(request, token);
			return Ok(output);
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
