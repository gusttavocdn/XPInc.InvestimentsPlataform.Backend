using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Database.models;

public class TransactionHistoryModel
{
	[Key] [Required] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }

	[Required]
	public string AccountId { get; set; } = null!;

	[Required]
	[Column(TypeName = "decimal(10, 2)")]
	public decimal Value { get; set; }

	[Required]
	public TransactionType TransactionType { get; set; }

	[Required]
	public string CreatedAt { get; set; } = null!;

	public virtual required AccountModel Account { get; set; }
}

public enum TransactionType
{
	Deposit,
	Withdraw
}
