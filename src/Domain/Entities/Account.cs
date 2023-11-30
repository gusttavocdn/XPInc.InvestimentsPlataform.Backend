namespace Domain.Entities;

public class Account : BaseEntity
{
	public string ClientId { get; }
	public decimal Balance { get; }
	public decimal InvestmentsValue { get; }
	public decimal TotalAssets { get; }

	public Account
	(
		string clientId, decimal balance, decimal investmentsValue, decimal totalAssets
	)
	{
		ClientId = clientId;
		Balance = balance;
		InvestmentsValue = investmentsValue;
		TotalAssets = totalAssets;
	}

	public Account
	(
		string id, string clientId, decimal balance, decimal investmentsValue, decimal totalAssets
	) : base(id)
	{
		ClientId = clientId;
		Balance = balance;
		InvestmentsValue = investmentsValue;
		TotalAssets = totalAssets;
	}
}