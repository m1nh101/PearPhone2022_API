using Core.Interfaces;
using Core.Model;

namespace Core.Service;

public class ReceiptForExcel:IReceiptForExcel
{
    private readonly IAppDbContext _appDbContext;

    public ReceiptForExcel(IAppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public List<ExcelModel> GetReciptForExcel(int oderId)
    {
        var lstReceipt = _appDbContext.Receipts
            .Join(_appDbContext.Vouchers, x => x.VoucherId,
                                    y => y.Id, 
                                    (x, y) => new {receipt = x, voucher = y})
            .Where(c => c.receipt.OrderId == oderId).Select(c=> new ExcelModel()
            {
                OrderId = c.receipt.OrderId,
                Seller = c.receipt.Seller,
                Total = c.receipt.Total,
                Description = c.receipt.Description,
                AddressId = c.receipt.AddressId,
                NameVoucher = c.voucher.Name,
                Status = c.receipt.Status
            }).ToList();
        return lstReceipt;
    }
}