using Application.Dtos.Requests;
using Application.Dtos.Requests.Clients;
using Application.Exceptions;
using Application.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/v1")]
public class ClientsController : ControllerBase
{
	private readonly ISignInUseCase _signInUseCase;
	private readonly ISignUpUseCase _signUpUseCase;

	public ClientsController(ISignInUseCase signInUseCase, ISignUpUseCase signUpUseCase)
	{
		_signInUseCase = signInUseCase;
		_signUpUseCase = signUpUseCase;
	}

	[HttpPost]
	[Route("login")]
	public async Task<IActionResult> SignIn([FromBody] SignInRequest request)
	{
		try
		{
			if (ModelState.IsValid is false)
				return BadRequest(ModelState);

			var output = await _signInUseCase.ExecuteAsync(request);
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
	[Route("register")]
	public async Task<IActionResult> SignUp([FromBody] SignUpRequest request)
	{
		try
		{
			if (ModelState.IsValid is false)
				return BadRequest(ModelState);

			await _signUpUseCase.ExecuteAsync(request);
			return Created("Account created", null);
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