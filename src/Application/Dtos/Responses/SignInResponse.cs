namespace Application.Dtos.Responses;

public class SignInResponse
{
	public string Token { get; set; }

	public SignInResponse(string token)
	{
		Token = token;
	}
}