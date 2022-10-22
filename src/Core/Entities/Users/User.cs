using Microsoft.AspNetCore.Identity;
using Shared.Enums;

namespace Core.Entities.Users;

public partial class User : IdentityUser
{ 
  private User() {}
  public User(string firstName, string lastName, string username, string email)
    :base(username)
  {
    FirstName = firstName;
    LastName = lastName;
    Email = email;
    Active = true;
  }

  public static User Empty() => new User();

  /// <summary>
  /// get or set status of user
  /// </summary>
  public bool Active { get; private set; }

  /// <summary>
  /// get or set avatar photos url
  /// </summary>
  public string Avatar { get; private set; } = string.Empty;

  /// <summary>
  /// get or set birthday
  /// </summary>
  public DateTime Birthday { get; private set; }

  /// <summary>
  /// get or set gender
  /// </summary>
  /// <value>
  /// default value is Gender.Other
  /// </value>
  public Gender Gender { get; private set; } = Gender.Other;
  
  /// <summary>
  /// get or set FirstName
  /// </summary>
  public string FirstName { get; private set; } = string.Empty;

  /// <summary>
  /// get or set LastName
  /// </summary>
  public string LastName { get; private set; } = string.Empty;

  /// <summary>
  /// get or set MiddleName
  /// </summary>
  /// <value>
  /// MiddleName is optional
  /// </value>
  public string? MiddleName { get; private set; }
}