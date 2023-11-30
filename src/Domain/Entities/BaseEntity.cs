namespace Domain.Entities;

public class BaseEntity
{
	public string Id { get; }

	public BaseEntity(string id)
	{
		Id = id;
	}

	public BaseEntity()
	{
		Id = Guid.NewGuid().ToString();
	}
}