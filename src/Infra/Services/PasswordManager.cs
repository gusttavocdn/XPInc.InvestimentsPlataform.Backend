using Application.Interfaces.Services;
using BCrypt.Net;

namespace Infra.Services;

public class PasswordManager : IPasswordManager
{
	public string Hash(string password)
	{
		return BCrypt.Net.BCrypt.EnhancedHashPassword(password, HashType.SHA256);
	}

	public bool Verify(string password, string hash)
	{
		return BCrypt.Net.BCrypt.EnhancedVerify(password, hash, HashType.SHA256);
	}
}