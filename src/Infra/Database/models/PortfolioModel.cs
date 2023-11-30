using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Database.models;

public class PortfolioModel
{
	[Key] [Required] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }

	[Required]
	public int AssetId { get; set; }

	[Required]
	public string AccountId { get; set; } = null!;

	[Required]
	[StringLength(10)]
	public string Symbol { get; set; } = null!;

	[Required]
	public int Quantity { get; set; }

	[Required] [Column(TypeName = "decimal(10,2)")]
	public decimal AveragePurchasePrice { get; set; }

	[Required] [Column(TypeName = "decimal(10,2)")]
	public decimal AcquisitionValue { get; set; }

	[Required] [Column(TypeName = "decimal(10,2)")]
	public decimal CurrentValue { get; set; }

	[Required] [Column(TypeName = "decimal(10,2)")]
	public decimal ProfitabilityPercentage { get; set; }

	[Required] [Column(TypeName = "decimal(10,2)")]
	public decimal ProfitabilityValue { get; set; }

	[Required]
	public string CreatedAt { get; set; } = null!;

	[Required]
	public string UpdatedAt { get; set; } = null!;

	public virtual AssetModel? Asset { get; set; }
	public virtual AccountModel? Account { get; set; }
}