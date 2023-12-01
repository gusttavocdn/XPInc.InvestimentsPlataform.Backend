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
	public string TransactionType { get; set; }

	[Required]
	public DateTime CreatedAt { get; } = DateTime.Now;

	public virtual AccountModel Account { get; set; }
}

public enum TransactionType
{
	Deposit,
	Withdraw
}