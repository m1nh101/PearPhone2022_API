using Shared.Bases;

namespace Core.Entities.Phones;

public class Color : Entity
{
  private Color() { }
  public Color(string name, string url)
  {
    if (string.IsNullOrEmpty(name))
      throw new ArgumentNullException(nameof(name), "Tên màu không được trống");

    if (string.IsNullOrEmpty(url))
      throw new ArgumentNullException(nameof(url), "ảnh đại diện cho màu không được trống");

    Name = name;
    Url = url;
  }

  /// <summary>
  /// get or set name of color
  /// </summary>
  public string Name { get; private set; } = string.Empty;

  /// <summary>
  /// get or set rgb code of color
  /// </summary>
  public string Url { get; private set; } = string.Empty;

  public ICollection<Stock>? Stocks { get; private set; }
  public ICollection<Image>? Images { get; private set; }
}