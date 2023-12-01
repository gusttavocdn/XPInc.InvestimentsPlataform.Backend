using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Database.models;

public class AccountModel
{
	[Key] [Required]
	public string Id { get; set; } = string.Empty;

	[Required]
	public string ClientId { get; set; } = string.Empty;

	[Required]
	[Column(TypeName = "decimal(10, 2)")]
	public decimal Balance { get; set; }

	[Required]
	public DateTime CreatedAt { get; } = DateTime.Now;

	[Required]
	public DateTime UpdatedAt { get; set; } = DateTime.Now;

	public virtual ClientModel Client { get; set; } = null!;
	public virtual IEnumerable<TransactionHistoryModel> TransactionHistory { get; set; } = null!;
	public virtual IEnumerable<InvestmentsHistoryModel> InvestmentsHistory { get; set; } = null!;
	public virtual IEnumerable<PortfolioModel> Portfolios { get; set; } = null!;
}