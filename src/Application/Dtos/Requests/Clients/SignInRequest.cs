using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Requests.Clients;

public class SignInRequest
{
	[Required(ErrorMessage = "Email is required")]
	[EmailAddress(ErrorMessage = "Invalid Email Address")]
	[MaxLength(255, ErrorMessage = "Email can't be longer than 255 characters")]
	public string Email { get; set; }

	[Required(ErrorMessage = "Password is required.")]
	[MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
	[MaxLength(15, ErrorMessage = "Password can't be longer than 15 characters")]
	public string Password { get; set; }

	public SignInRequest(string email, string password)
	{
		Email = email;
		Password = password;
	}
}
