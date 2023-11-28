using Application.Dtos.Requests;
using Application.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/v1/[controller]")]
public class SignUpController : ControllerBase
{
	private readonly ISignUpUseCase _signUpUseCase;

	public SignUpController(ISignUpUseCase signUpUseCase)
	{
		_signUpUseCase = signUpUseCase;
	}

	[HttpPost]
	public async Task<IActionResult> SignUp([FromBody] SignUpRequest request)
	{
		var output = await _signUpUseCase.ExecuteAsync(request);
		return output is null ? BadRequest() : Created("Account Created", null);
	}
}
