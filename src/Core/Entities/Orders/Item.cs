using Core.Entities.Stocks;
using Shared.Bases;

namespace Core.Entities.Orders;

public class Item : ModifierEntity
{
    /// <summary>
    /// get or set quantity
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// get or set price of product
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// get or set total price of item
    /// </summary>
    public double Total { get; set; }

    /// <summary>
    /// get or set order id
    /// </summary>
    public int OrderId { get; set; }

    /// <summary>
    /// get or set phone id
    /// </summary>
    public int PhoneId { get; set; }

    /// <summary>
    /// get or set order object
    /// </summary>
    public virtual Order? Order { get; set; }

    /// <summary>
    /// get or set phone object
    /// </summary>
    public virtual Phone? Phone { get; set; }
}