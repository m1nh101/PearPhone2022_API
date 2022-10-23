using Shared.Bases;

namespace Core.Entities.Phones;

public class Branch : Entity
{
    /// <summary>
    /// get or set name of branch
    /// </summary>
    public string Name { get; set; } = string.Empty;

    public ICollection<Phone> Phones { get; set; } = new List<Phone>();
}