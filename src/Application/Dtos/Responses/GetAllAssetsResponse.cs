using Domain.Entities.Asset;

namespace Application.Dtos.Responses;

public class GetAllAssetsResponse
{
	public IEnumerable<Asset> Assets { get; set; }

	public GetAllAssetsResponse(IEnumerable<Asset> assets)
	{
		Assets = assets;
	}
}
