namespace Application.Dtos.Responses.Investments;

public class SellAssetResponse
{
	public string Symbol { get; set; }

	public int Quantity { get; set; }
	public decimal UnitPrice { get; set; }
	public decimal TotalPrice { get; set; }

	public SellAssetResponse(string symbol, int quantity, decimal unitPrice, decimal totalPrice)
	{
		Symbol = symbol;
		Quantity = quantity;
		UnitPrice = unitPrice;
		TotalPrice = totalPrice;
	}
}
