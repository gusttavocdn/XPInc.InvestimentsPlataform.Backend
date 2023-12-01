namespace Domain.Entities;

public class Account : BaseEntity
{
	public string ClientId { get; }
	public decimal Balance { get; }

	public Account
	(
		string clientId, decimal balance
	)
	{
		ClientId = clientId;
		Balance = balance;
	}

	public Account
	(
		string id, string clientId, decimal balance
	) : base(id)
	{
		ClientId = clientId;
		Balance = balance;
	}
}