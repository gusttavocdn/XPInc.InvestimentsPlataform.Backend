using Domain.Entities;

namespace Application.Dtos.Responses.Assets;

public class GetAllAssetsResponse
{
	public IEnumerable<Asset> Assets { get; set; }

	public GetAllAssetsResponse(IEnumerable<Asset> assets)
	{
		Assets = assets;
	}
}
