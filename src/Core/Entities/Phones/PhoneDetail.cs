using Shared.Bases;

namespace Core.Entities.Phones;

public class PhoneDetail : Entity
{
    /// <summary>
    /// get or set battery of phone
    /// </summary>
    public string Battery { get; private set; } = string.Empty;

    /// <summary>
    /// get or set screen information of phone
    /// </summary>
    public string Screen { get; private set; } = string.Empty;

    /// <summary>
    /// get or set operating system and current version that installed in the phone
    /// </summary>
    public string OS { get; private set; } = string.Empty;

    /// <summary>
    /// get or set charge information of phone
    /// </summary>
    public string Charger { get; private set; } = string.Empty;

    /// <summary>
    /// get or set CPU of phone
    /// </summary>
    public string CPU { get; private set; } = string.Empty;

    /// <summary>
    /// get or set memory of phone
    /// </summary>
    public string RAM { get; private set; } = string.Empty;

    /// <summary>
    /// get or set camera information phone use
    /// </summary>
    public string Camera { get; private set; } = string.Empty;

    /// <summary>
    /// get or set audio information
    /// </summary>
    public string Audio { get; private set; } = string.Empty;

    /// <summary>
    /// get or set security feature of phone
    /// </summary>
    public string? Security { get; private set; } = string.Empty;

    /// <summary>
    /// get or set connection types phone support
    /// </summary>
    public string Connection { get; private set; } = string.Empty;

    //navigation and foreign key
    public virtual ICollection<Stock> Stocks { get; private set; } = null!;
}