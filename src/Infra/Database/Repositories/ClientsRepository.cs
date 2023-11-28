using Application.Interfaces.Repositories;
using Domain.Entities.Client;
using Infra.Database.Context;
using Infra.Database.models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.Repositories;

public class ClientsRepository : IClientsRepository
{
	private readonly ApplicationDbContext _context;

	public ClientsRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<bool> CreateAsync(Client client)
	{
		var clientModel = new ClientModel
		{
			Id = client.Id,
			Name = client.Name,
			Email = client.Email,
			Password = client.Password
		};

		if (await _context.Clients.AddAsync(clientModel) is null)
			return false;
		_context.SaveChanges();
		return true;
	}

	public async Task<Client?> GetByEmailAsync(string requestEmail)
	{
		var client = await _context.Clients.FirstOrDefaultAsync
			(client => client.Email == requestEmail);
		if (client is null)
			return null;
		return new Client(client.Name, client.Email, client.Password);
	}
}
