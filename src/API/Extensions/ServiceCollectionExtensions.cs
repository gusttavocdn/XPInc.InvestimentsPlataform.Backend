using System.Diagnostics.CodeAnalysis;
using System.Text;
using API.OptionsSetup;
using Application.Interfaces.Services;
using Application.Interfaces.UseCases;
using Application.UseCases;
using Infra.Authentication;
using Infra.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
	public static void AddUseCases(this IServiceCollection services)
	{
		services
			.AddScoped<ISignUpUseCase, SignUpUseCase>()
			.AddScoped<ISignInUseCase, SignInUseCase>()
			.AddScoped<IGetAllAssetsUseCase, GetAllAssetsUseCase>()
			.AddScoped<IGetAssetBySymbolUseCase, GetAssetBySymbolUseCase>()
			.AddScoped<IBuyAssetUseCase, BuyAssetUseCase>();
	}

	public static void AddServices(this IServiceCollection services)
	{
		services.AddSingleton<IPasswordManager, PasswordManager>();
		services.AddSingleton<IJwtProvider, JwtProvider>();
	}

	public static void AddJwtAuthentication
		(this IServiceCollection services, IConfiguration configuration)
	{
		services
			.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			.AddJwtBearer
			(
				x =>
					x.TokenValidationParameters = new TokenValidationParameters
					{
						ValidIssuer = configuration["JwtSettings:Issuer"],
						ValidAudience = configuration["JwtSettings:Audience"],
						IssuerSigningKey = new SymmetricSecurityKey
							(Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"]!)),
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true
					}
			);
		services.ConfigureOptions<JwtOptionsSetup>();
		// services.ConfigureOptions<JwtBearerOptionsSetup>();
		services.AddAuthorization();
	}
}
