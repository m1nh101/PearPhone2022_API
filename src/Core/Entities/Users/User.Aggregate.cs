using Shared.Interfaces;

namespace Core.Entities.Users;

public partial class User : IAggregateRoot
{
  public string GetFullName() => $"{FirstName}{(string.IsNullOrEmpty(MiddleName) ? string.Empty : $" {MiddleName}")} {LastName}";
  public void SetStatus(bool isActive) => Active = isActive;
}