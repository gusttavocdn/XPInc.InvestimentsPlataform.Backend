using System.ComponentModel.DataAnnotations;

namespace Infra.Database.models;

public class ClientModel
{
	[Key] [Required]
	public string Id { get; set; } = string.Empty;

	[Required]
	public string Name { get; set; } = string.Empty;

	[Required]
	public string Email { get; set; } = string.Empty;

	[Required]
	public string Password { get; set; } = string.Empty;

	public virtual AccountModel? Account { get; set; }
}