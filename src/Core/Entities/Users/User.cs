using Microsoft.AspNetCore.Identity;
using Shared.Enums;

namespace Core.Entities.Users;

public partial class User : IdentityUser
{
  /// <summary>
  /// get or set status of user
  /// </summary>
  public bool Active { get; set; }

  /// <summary>
  /// get or set avatar photos url
  /// </summary>
  public string Avatar { get; set; } = string.Empty;

  /// <summary>
  /// get or set birthday
  /// </summary>
  public DateTime Birthday { get; set; }

  /// <summary>
  /// get or set gender
  /// </summary>
  /// <value>
  /// default value is Gender.Other
  /// </value>
  public Gender Gender { get; set; } = Gender.Other;
  
  /// <summary>
  /// get or set FirstName
  /// </summary>
  public string FirstName { get; set; } = string.Empty;

  /// <summary>
  /// get or set LastName
  /// </summary>
  public string LastName { get; set; } = string.Empty;

  /// <summary>
  /// get or set MiddleName
  /// </summary>
  /// <value>
  /// MiddleName is optional
  /// </value>
  public string? MiddleName { get; set; }
}