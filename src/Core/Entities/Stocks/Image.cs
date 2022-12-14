using Shared.Bases;

namespace Core.Entities.Stocks;

public class Image : Entity
{
  private Image() { }
  public Image(string url)
  {
    Url = url;
  }

  /// <summary>
  /// get or set url of image
  /// </summary>
  public string Url { get; set; } = string.Empty;

  /// <summary>
  /// get or set phone id that own this image 
  /// </summary>
  public int PhoneId { get; set; }

  /// <summary>
  /// get or set concrete phone that own this image
  /// </summary>
  public virtual Phone? Phone { get; set; }
}