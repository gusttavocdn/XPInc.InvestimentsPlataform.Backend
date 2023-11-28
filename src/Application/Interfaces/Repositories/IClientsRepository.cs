using Domain.Entities.Client;

namespace Application.Interfaces.Repositories;

public interface IClientsRepository
{
	Task<bool> CreateAsync(Client client);
}
