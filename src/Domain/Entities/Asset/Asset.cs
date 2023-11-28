namespace Domain.Entities.Asset;

public class Asset
{
	public string Symbol { get; set; }
	public string Name { get; set; }
	public int AvailableQuantity { get; set; }
	public decimal Price { get; set; }

	public Asset(string symbol, string name, int availableQuantity, decimal price)
	{
		Symbol = symbol;
		Name = name;
		AvailableQuantity = availableQuantity;
		Price = price;
	}
}
