using Domain.Entities;

namespace Application.Dtos.Responses.Assets;

public class GetAssetBySymbolResponse
{
	public Asset? Asset { get; set; }

	public GetAssetBySymbolResponse(Asset? asset)
	{
		Asset = asset;
	}
}
