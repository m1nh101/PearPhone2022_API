using Shared.Bases;

namespace Core.Entities.Phones;

public class Image : Entity
{
  private Image() { }
  public Image(string url)
  {
    if(string.IsNullOrEmpty(url))
      throw new ArgumentNullException("đường dẫn ảnh không được trống");

    Url = url;
  }

  /// <summary>
  /// get or set url of image
  /// </summary>
  public string Url { get; private set; } = string.Empty;
  public int? ColorId { get; private set; }
  public virtual Color? Color { get; private set; }

  /// <summary>
  /// get or set phone id that own this image 
  /// </summary>
  public int PhoneId { get; private set; }

  /// <summary>
  /// get or set concrete phone that own this image
  /// </summary>
  public virtual Phone? Phone { get; private set; }
}