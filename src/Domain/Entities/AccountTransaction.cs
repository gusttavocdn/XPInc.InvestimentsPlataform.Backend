namespace Domain.Entities;

public class AccountTransaction
{
	public int Id { get; }
	public string TransactionType { get; }
	public decimal Value { get; }
	public DateTime CreatedAt { get; }

	public AccountTransaction(int id, string transactionType, decimal value, DateTime createdAt)
	{
		Id = id;
		TransactionType = transactionType;
		Value = value;
		CreatedAt = createdAt;
	}
}