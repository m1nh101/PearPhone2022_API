using Shared.Bases;

namespace Core.Entities.Phones;

public class Color : Entity
{
    /// <summary>
    /// get or set name of color
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// get or set rgb code of color
    /// </summary>
    public string RGB { get; set; } = string.Empty;

    public ICollection<Stock>? Stocks { get; set; }
}