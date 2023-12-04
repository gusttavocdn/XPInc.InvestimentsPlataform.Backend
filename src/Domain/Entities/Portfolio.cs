namespace Domain.Entities;

public class Portfolio : BaseEntity
{
	public int Id { get; set; }
	public int AssetId { get; set; }
	public string AccountId { get; set; }
	public string Symbol { get; set; }
	public int Quantity { get; set; }
	public decimal AveragePurchasePrice { get; set; }
	public decimal AcquisitionValue { get; set; }
	public decimal CurrentValue { get; set; }
	public decimal ProfitabilityPercentage { get; set; }
	public decimal ProfitabilityValue { get; set; }
}
