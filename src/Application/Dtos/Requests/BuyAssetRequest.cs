using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Requests;

public class BuyAssetRequest
{
	[Required(ErrorMessage = "The asset is required")]
	public string AssetSymbol { get; set; }

	[Required(ErrorMessage = "The asset quantity is required")]
	public int Quantity { get; set; }

	public string userToken { get; set; }
}