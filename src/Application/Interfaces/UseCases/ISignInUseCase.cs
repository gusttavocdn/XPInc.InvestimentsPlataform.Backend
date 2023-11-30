using Application.Commons;
using Application.Dtos.Requests;
using Application.Dtos.Responses;

namespace Application.Interfaces.UseCases;

public interface ISignInUseCase : IUseCase<SignInRequest, SignInResponse>
{
}