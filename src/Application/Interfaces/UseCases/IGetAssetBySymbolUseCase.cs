using Application.Commons.Interfaces;
using Application.Dtos.Responses;

namespace Application.Interfaces.UseCases;

public interface IGetAssetBySymbolUseCase : IUseCase<string, GetAssetBySymbolResponse>
{
}