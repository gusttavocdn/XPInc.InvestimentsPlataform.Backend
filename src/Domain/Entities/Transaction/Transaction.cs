using Domain.Enums;

namespace Domain.Entities.Transaction;

public class Transaction : BaseEntity
{
	public string AccountId { get; }
	public decimal Value { get; }
	public TransactionTypeEnum TransactionType { get; }
	public DateTime CreatedAt { get; }
	public Account.Account Account { get; }

	public Transaction
	(
		string accountId, decimal value, TransactionTypeEnum transactionType,
		Account.Account account
	)
	{
		AccountId = accountId;
		Value = value;
		TransactionType = transactionType;
		Account = account;
		CreatedAt = DateTime.Now;
	}
}
