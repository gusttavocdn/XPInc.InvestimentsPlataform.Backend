using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infra.Database.Context;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
	public ApplicationDbContext CreateDbContext(string[] args)
	{
		var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
		// TODO: Change this to a environment variable
		// var connectionString =
		// 	"Server=viaduct.proxy.rlwy.net; Port=39071; Database=railway; Uid=root; Pwd=6B55Fg3HbeEca-FEDHEGfEEB-DDG1C6f;";
		var connectionString = "Server=localhost; Database=Investments; Uid=root; Pwd=passwd;";

		optionsBuilder.UseMySql
		(
			connectionString,
			new MySqlServerVersion
			(
				ServerVersion.AutoDetect(connectionString)
			),
			options => options.MigrationsAssembly("Infra")
		);

		return new ApplicationDbContext(optionsBuilder.Options);
	}
}
