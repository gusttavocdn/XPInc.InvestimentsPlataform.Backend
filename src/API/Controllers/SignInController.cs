using Application.Dtos.Requests;
using Application.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/v1/login")]
public class SignInController : ControllerBase
{
	private readonly ISignInUseCase _signInUseCase;

	public SignInController(ISignInUseCase signInUseCase)
	{
		_signInUseCase = signInUseCase;
	}

	[HttpPost]
	public async Task<IActionResult> SignIn([FromBody] SignInRequest request)
	{
		if (ModelState.IsValid is false)
			return BadRequest(ModelState);

		var output = await _signInUseCase.ExecuteAsync(request);
		return output is null ? BadRequest() : Ok(output);
	}
}
