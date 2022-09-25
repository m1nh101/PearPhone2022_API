namespace Shared.Bases;

public abstract class ModifierEntity : Entity
{
  /// <summary>
  /// get or set time entity created
  /// </summary>
  public DateTime CreatedAt { get; set; }

  /// <summary>
  /// get or set time entity updated
  /// </summary>
  public DateTime UpdatedAt { get; set; }

  /// <summary>
  /// get or set user who created the entity
  /// </summary>
  public string CreatedBy { get; set; } = string.Empty;

  /// <summary>
  /// get or set user who updated the entity
  /// </summary>
  public string UpdatedBy { get; set; } = string.Empty;
}