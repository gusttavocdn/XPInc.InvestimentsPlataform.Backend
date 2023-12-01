using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Database.models;

public class AssetModel
{
	[Key] [Required] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; init; }

	[Required]
	public string Symbol { get; set; } = string.Empty;

	[Required]
	public string Name { get; set; } = string.Empty;

	[Required]
	public int AvailableQuantity { get; set; }

	[Required]
	[Column(TypeName = "decimal(10, 2)")]
	public decimal Price { get; set; }

	public virtual IEnumerable<PortfolioModel> Portfolios { get; set; } = null!;
	public virtual IEnumerable<InvestmentsHistoryModel> InvestmentsHistory { get; set; } = null!;
}