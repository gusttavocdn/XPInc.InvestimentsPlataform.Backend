namespace Domain.Entities.Account;

public class Account : BaseEntity
{
	public string ClientId { get; }
	public decimal Balance { get; }
	public decimal InvestmentsValue { get; }
	public decimal TotalAssets { get; }
	public DateTime CreatedAt { get; }
	public DateTime UpdatedAt { get; }
	// public Client.Client Client { get; }

	public Account
	(
		string clientId, decimal balance, decimal investmentsValue, decimal totalAssets
	)
	{
		ClientId = clientId;
		Balance = balance;
		InvestmentsValue = investmentsValue;
		TotalAssets = totalAssets;
		CreatedAt = DateTime.Now;
		UpdatedAt = DateTime.Now;
		// Client = client;
	}
}
