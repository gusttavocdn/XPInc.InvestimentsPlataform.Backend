using Domain.Enums;

namespace Domain.Entities;

public class InvestmentTransaction
{
	public string AssetId { get; }
	public decimal Value { get; }
	public InvestmentTypeEnum InvestmentType { get; }
	public DateTime CreatedAt { get; }
	public Account Account { get; }

	public InvestmentTransaction
	(
		string assetId, decimal value, InvestmentTypeEnum investmentType,
		DateTime createdAt, Account account
	)
	{
		AssetId = assetId;
		Value = value;
		InvestmentType = investmentType;
		CreatedAt = createdAt;
		Account = account;
	}
}
