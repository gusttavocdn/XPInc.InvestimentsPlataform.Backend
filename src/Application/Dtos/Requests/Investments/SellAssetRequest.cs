using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Requests.Investments;

public class SellAssetRequest
{
	[Required(ErrorMessage = "The asset is required")]
	public string AssetSymbol { get; set; }

	[Required(ErrorMessage = "The asset quantity is required")]
	public int Quantity { get; set; }
}
