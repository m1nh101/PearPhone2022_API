using Core.Entities.Users;

namespace Core.Interfaces;

public interface IJwtHelper
{
	Task<string> GenerateJwtToken();
	void SetUser(User user);
}