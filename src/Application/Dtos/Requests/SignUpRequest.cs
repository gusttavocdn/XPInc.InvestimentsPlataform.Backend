namespace Application.Dtos.Requests;

public class SignUpRequest
{
	public string Name { get; }
	public string Email { get; }
	public string Password { get; }

	public SignUpRequest(string name, string email, string password)
	{
		Name = name;
		Email = email;
		Password = password;
	}
}
