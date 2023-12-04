using System.Diagnostics.CodeAnalysis;
using Application.Interfaces.Repositories;
using Infra.Database.Context;
using Infra.Database.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

[ExcludeFromCodeCoverage]
public static class InfrastructureExtensions
{
	public static void AddInfrastructure
		(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddMySql(configuration);
		services.AddRepositories();
	}

	private static void AddMySql(this IServiceCollection services, IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("MySqlLocal");

		services.AddDbContext<ApplicationDbContext>
		(
			options =>
			{
				options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
			}
		);
	}

	private static void AddRepositories(this IServiceCollection services)
	{
		services
			.AddScoped<IClientsRepository, ClientsRepository>()
			.AddScoped<IAccountsRepository, AccountsRepository>()
			.AddScoped<IAssetsRepository, AssetsRepository>()
			.AddScoped<IInvestmentsHistoryRepository, InvestmentsHistoryRepository>()
			.AddScoped<IPortfolioRepository, PortfolioRepository>();
	}
}
