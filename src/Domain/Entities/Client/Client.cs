namespace Domain.Entities.Client;

public class Client : BaseEntity
{
	public string Name { get; }
	public string Email { get; }
	public string Password { get; }
	public Account.Account Account { get; }

	public Client(string name, string email, string password, Account.Account account)
	{
		Name = name;
		Email = email;
		Password = password;
		Account = account;
	}
}
