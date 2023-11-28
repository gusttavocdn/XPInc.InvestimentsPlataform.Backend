using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infra.Database.Context;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
	public ApplicationDbContext CreateDbContext(string[] args)
	{
		var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
		// TODO: Change this to a environment variable
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
