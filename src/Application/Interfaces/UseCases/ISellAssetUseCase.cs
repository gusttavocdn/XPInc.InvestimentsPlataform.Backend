using Application.Commons.Interfaces;
using Application.Dtos.Requests;
using Application.Dtos.Responses;

namespace Application.Interfaces.UseCases;

public interface ISellAssetUseCase : IUseCase<SellAssetRequest, SellAssetResponse>
{
}