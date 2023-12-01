namespace Domain.Entities;

public class InvestmentTransaction
{
	public int Id { get; set; }
	public int AssetId { get; }
	public decimal Value { get; }
	public string InvestmentType { get; }
	public DateTime CreatedAt { get; }

	public InvestmentTransaction
	(
		int id, int assetId, decimal value, string investmentType,
		DateTime createdAt
	)
	{
		Id = id;
		AssetId = assetId;
		Value = value;
		InvestmentType = investmentType;
		CreatedAt = createdAt;
	}
}