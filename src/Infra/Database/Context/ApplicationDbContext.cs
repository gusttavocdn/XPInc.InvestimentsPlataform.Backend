using Infra.Database.models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.Context;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{
	}

	public DbSet<ClientModel> Clients { get; set; } = null!;
	public DbSet<AccountModel> Accounts { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<ClientModel>()
			.HasOne(c => c.Account)
			.WithOne(a => a.Client)
			.HasForeignKey<AccountModel>(a => a.ClientId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
