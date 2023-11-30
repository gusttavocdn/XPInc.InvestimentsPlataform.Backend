namespace Domain.Entities;

public class Asset
{
	public int Id { get; set; }
	public string Symbol { get; set; }
	public string Name { get; set; }
	public int AvailableQuantity { get; set; }
	public decimal Price { get; set; }

	public Asset(int id, string symbol, string name, int availableQuantity, decimal price)
	{
		Id = id;
		Symbol = symbol;
		Name = name;
		AvailableQuantity = availableQuantity;
		Price = price;
	}
}