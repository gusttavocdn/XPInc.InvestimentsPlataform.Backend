using Application.Commons;
using Application.Dtos.Requests;
using Application.Dtos.Responses;

namespace Application.Interfaces.UseCases;

public interface IBuyAssetUseCase : IUseCase<BuyAssetRequest, BuyAssetResponse>
{
}