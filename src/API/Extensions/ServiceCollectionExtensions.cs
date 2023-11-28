using System.Diagnostics.CodeAnalysis;
using Application.Interfaces.Services;
using Application.Interfaces.UseCases;
using Application.UseCases;
using Infra.Services;

namespace API.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
	public static void AddUseCases(this IServiceCollection services)
	{
		services
			.AddScoped<ISignUpUseCase, SignUpUseCase>()
			.AddScoped<ISignInUseCase, SignInUseCase>();
	}

	public static void AddServices(this IServiceCollection services)
	{
		services.AddSingleton<IPasswordManager, PasswordManager>();
	}
}
