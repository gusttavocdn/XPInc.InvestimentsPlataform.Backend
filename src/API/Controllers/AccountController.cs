using Application.Dtos.Requests.Account;
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
		var authorizationHeader = Request.Headers["Authorization"].ToString();
		var token = authorizationHeader["Bearer ".Length..].Trim();

		var output = await _getAccountBalanceUseCase.ExecuteAsync(new GetBalanceRequest(), token);
		return output is null ? BadRequest() : Ok(output);
	}

	[HttpPost("deposit")]
	public async Task<IActionResult> Deposit([FromBody] DepositRequest request)
	{
		var authorizationHeader = Request.Headers["Authorization"].ToString();
		var token = authorizationHeader["Bearer ".Length..].Trim();

		var output = await _depositUseCase.ExecuteAsync(request, token);
		return output is null ? BadRequest() : Ok(output);
	}

	[HttpPost("withdraw")]
	public async Task<IActionResult> Withdraw([FromBody] WithdrawRequest request)
	{
		var authorizationHeader = Request.Headers["Authorization"].ToString();
		var token = authorizationHeader["Bearer ".Length..].Trim();

		var output = await _withdrawUseCase.ExecuteAsync(request, token);
		return output is null ? BadRequest() : Ok(output);
	}

	[HttpGet("transactions")]
	public async Task<IActionResult> GetTransactionsExtract()
	{
		var authorizationHeader = Request.Headers["Authorization"].ToString();
		var token = authorizationHeader["Bearer ".Length..].Trim();

		var output = await _getTransactionsUseCase.ExecuteAsync
			(new GetTransactionsExtractRequest(), token);
		return output is null ? BadRequest() : Ok(output);
	}
}
