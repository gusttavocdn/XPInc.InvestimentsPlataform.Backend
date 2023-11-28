using System.Diagnostics.CodeAnalysis;
using Application.Interfaces.UseCases;
using Application.UseCases;

namespace API.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
	public static void AddUseCases(this IServiceCollection services)
	{
		services.AddScoped<ISignUpUseCase, SignUpUseCase>();
	}
}
