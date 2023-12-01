using Application.Dtos.Requests.Account;
using Application.Exceptions;
using Application.Interfaces.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/v1/account")]
[Authorize]
public class AccountController : ControllerBase
{
	private readonly IDepositUseCase _depositUseCase;
	private readonly IWithdrawUseCase _withdrawUseCase;
	private readonly IGetAccountBalanceUseCase _getAccountBalanceUseCase;
	private readonly IGetTransactionsUseCase _getTransactionsUseCase;

	public AccountController
	(
		IDepositUseCase depositUseCase, IWithdrawUseCase withdrawUseCase,
		IGetAccountBalanceUseCase getAccountBalanceUseCase,
		IGetTransactionsUseCase getTransactionsUseCase
	)
	{
		_depositUseCase = depositUseCase;
		_withdrawUseCase = withdrawUseCase;
		_getAccountBalanceUseCase = getAccountBalanceUseCase;
		_getTransactionsUseCase = getTransactionsUseCase;
	}

	[HttpGet("balance")]
	public async Task<IActionResult> GetAccountBalance()
	{
		try
		{
			if (ModelState.IsValid is false)
				return BadRequest(ModelState);

			var authorizationHeader = Request.Headers["Authorization"].ToString();
			var token = authorizationHeader["Bearer ".Length..].Trim();

			var output = await _getAccountBalanceUseCase.ExecuteAsync
				(new GetBalanceRequest(), token);
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

	[HttpPost("deposit")]
	public async Task<IActionResult> Deposit([FromBody] DepositRequest request)
	{
		try
		{
			if (ModelState.IsValid is false)
				return BadRequest(ModelState);

			var authorizationHeader = Request.Headers["Authorization"].ToString();
			var token = authorizationHeader["Bearer ".Length..].Trim();

			var output = await _depositUseCase.ExecuteAsync(request, token);
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

	[HttpPost("withdraw")]
	public async Task<IActionResult> Withdraw([FromBody] WithdrawRequest request)
	{
		try
		{
			var authorizationHeader = Request.Headers["Authorization"].ToString();
			var token = authorizationHeader["Bearer ".Length..].Trim();

			var output = await _withdrawUseCase.ExecuteAsync(request, token);
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

	[HttpGet("transactions")]
	public async Task<IActionResult> GetTransactionsExtract()
	{
		try
		{
			var authorizationHeader = Request.Headers["Authorization"].ToString();
			var token = authorizationHeader["Bearer ".Length..].Trim();

			var output = await _getTransactionsUseCase.ExecuteAsync
				(new GetTransactionsExtractRequest(), token);
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