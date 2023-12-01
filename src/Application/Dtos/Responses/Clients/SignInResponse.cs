namespace Application.Dtos.Responses.Clients;

public class SignInResponse
{
	public string Token { get; set; }

	public SignInResponse(string token)
	{
		Token = token;
	}
}
