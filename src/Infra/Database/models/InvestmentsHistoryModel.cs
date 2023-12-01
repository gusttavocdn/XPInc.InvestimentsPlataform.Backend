using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Database.models;

public class InvestmentsHistoryModel
{
	[Key] [Required] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }

	[Required]
	public string AccountId { get; set; } = null!;

	[Required]
	public int AssetId { get; set; }

	[Required]
	public string InvestmentType { get; set; }

	[Required]
	public int Quantity { get; set; }

	[Required] [Column(TypeName = "decimal(10,2)")]
	public decimal Price { get; set; }

	[Required]
	public DateTime CreatedAt { get; set; } = DateTime.Now;

	public virtual AssetModel? Asset { get; set; }
	public virtual AccountModel? Account { get; set; }
}