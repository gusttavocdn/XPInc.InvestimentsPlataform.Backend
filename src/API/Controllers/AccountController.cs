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

	public AccountController
	(
		IDepositUseCase depositUseCase, IWithdrawUseCase withdrawUseCase,
		IGetAccountBalanceUseCase getAccountBalanceUseCase
	)
	{
		_depositUseCase = depositUseCase;
		_withdrawUseCase = withdrawUseCase;
		_getAccountBalanceUseCase = getAccountBalanceUseCase;
	}

	[HttpGet("balance")]
	public async Task<IActionResult> GetAccountBalance([FromBody] GetBalanceRequest request)
	{
		var authorizationHeader = Request.Headers["Authorization"].ToString();
		var token = authorizationHeader["Bearer ".Length..].Trim();

		var output = await _getAccountBalanceUseCase.ExecuteAsync(request, token);
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
}
