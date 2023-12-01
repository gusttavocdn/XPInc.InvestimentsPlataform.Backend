using Infra.Database.models;
using Infra.Database.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.Context;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext
		(DbContextOptions<ApplicationDbContext> options) : base
		(options)
	{
	}

	public DbSet<ClientModel> Clients { get; set; } = null!;
	public DbSet<AccountModel> Accounts { get; set; } = null!;
	public DbSet<AssetModel> Assets { get; set; } = null!;
	public DbSet<PortfolioModel> Portfolios { get; set; } = null!;
	public DbSet<InvestmentsHistoryModel> InvestmentsHistory { get; set; } = null!;
	public DbSet<TransactionHistoryModel> TransactionHistory { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<ClientModel>()
			.HasOne(c => c.Account)
			.WithOne(a => a.Client)
			.HasForeignKey<AccountModel>(a => a.ClientId)
			.OnDelete(DeleteBehavior.Cascade);

		modelBuilder.Entity<AccountModel>()
			.HasMany(c => c.Portfolios)
			.WithOne(a => a.Account)
			.HasForeignKey(a => a.AccountId)
			.OnDelete(DeleteBehavior.Cascade);

		modelBuilder.Entity<AccountModel>()
			.HasMany(c => c.TransactionHistory)
			.WithOne(a => a.Account)
			.HasForeignKey(a => a.AccountId)
			.OnDelete(DeleteBehavior.Cascade);

		modelBuilder.Entity<AccountModel>()
			.HasMany(c => c.InvestmentsHistory)
			.WithOne(a => a.Account)
			.HasForeignKey(a => a.AccountId)
			.OnDelete(DeleteBehavior.Cascade);

		modelBuilder.Entity<AssetModel>()
			.HasMany(c => c.InvestmentsHistory)
			.WithOne(a => a.Asset)
			.HasForeignKey(a => a.AssetId)
			.OnDelete(DeleteBehavior.Cascade);

		modelBuilder.Entity<AssetModel>()
			.HasMany(c => c.Portfolios)
			.WithOne(a => a.Asset)
			.HasForeignKey(a => a.AssetId)
			.OnDelete(DeleteBehavior.Cascade);

		modelBuilder.AssetsSeed();
	}
}