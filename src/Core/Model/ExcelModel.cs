using Shared.Enums;

namespace Core.Model;

public class ExcelModel
{
    public int Id { get; set; }
    public string Seller { get; set; } = string.Empty;

    public double Total { get; set; }

    public Status Status { get; set; } = Status.Inprocess;

    public string Description { get; set; } = string.Empty;
    
    public int OrderId { get; set; }

    public int AddressId { get; set; }

    public string NameVoucher { get;  set; }
}