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
	[Column(TypeName = "decimal(10, 2)")]
	public decimal InvestmentsValue { get; set; }

	[Required]
	[Column(TypeName = "decimal(10, 2)")]
	public decimal TotalAssets { get; set; }

	[Required]
	public string CreatedAt { get; set; }

	[Required]
	public string UpdatedAt { get; set; }

	public virtual ClientModel Client { get; set; } = null!;
	public virtual IEnumerable<TransactionHistoryModel> TransactionHistory { get; set; } = null!;
	public virtual IEnumerable<InvestmentsHistoryModel> InvestmentsHistory { get; set; } = null!;
	public virtual IEnumerable<PortfolioModel> Portfolios { get; set; } = null!;
}
