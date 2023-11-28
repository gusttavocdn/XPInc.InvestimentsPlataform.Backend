using Infra.Database.models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.Seeds;

public static class ClientsDemo
{
	public static void ClientsSeed(this ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<ClientModel>().HasData
		(
			new ClientModel
			{
				Id = Guid.NewGuid().ToString(), Name = "Leonardo", Email = "leonardo@gmail.com",
				Password = "$2b$10$B2bXfD5bLEBbyysht4lGU.Zouki5gJmU4mISQoQZ83ECQ3XIN/Qt2"
			},
			new ClientModel
			{
				Id = Guid.NewGuid().ToString(), Name = "Jose", Email = "jose@gmail.com",
				Password = "$2b$10$eS5g40R9O6FrSDtor1sSq.97bptZnBC6c0BzdkB/6YnJjPrZ1qBFG"
			}
		);
	}
}
