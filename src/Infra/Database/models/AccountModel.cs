using System.ComponentModel.DataAnnotations;

namespace Infra.Database.models;

public class AccountModel
{
	[Key] [Required]
	public string Id { get; set; } = string.Empty;

	[Required]
	public string ClientId { get; set; } = string.Empty;

	[Required]
	public decimal Balance { get; set; }

	[Required]
	public decimal InvestmentsValue { get; set; }

	[Required]
	public decimal TotalAssets { get; set; }

	[Required]
	public DateTime CreatedAt { get; set; }

	[Required]
	public DateTime UpdatedAt { get; set; }

	public virtual ClientModel? Client { get; set; }
}