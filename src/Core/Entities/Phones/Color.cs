using Shared.Bases;

namespace Core.Entities.Phones;

public class Color : Entity
{
    private Color() {}
    public Color(string name, string rgb)
    {
        Name = name;
        RGB = rgb;
    }

    /// <summary>
    /// get or set name of color
    /// </summary>
    public string Name { get; private set; } = string.Empty;

    /// <summary>
    /// get or set rgb code of color
    /// </summary>
    public string RGB { get; private set; } = string.Empty;

    public ICollection<Stock>? Stocks { get; private set; }
}