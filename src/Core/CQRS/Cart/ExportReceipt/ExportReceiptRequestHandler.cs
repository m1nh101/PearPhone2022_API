using ClosedXML.Excel;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.CQRS.Cart.ExportReceipt;

public sealed class ExportReceiptRequestHandler
  : IRequestHandler<ExportReceiptRequest, MemoryStream>
{
  private readonly IAppDbContext _context;
  private readonly IExcelExtractor _extractor;

  public ExportReceiptRequestHandler(IAppDbContext context,
    IExcelExtractor extractor)
  {
    _context = context;
    _extractor = extractor;
  }

  public async Task<MemoryStream> Handle(ExportReceiptRequest request, CancellationToken cancellationToken)
  {
    var receipt = await _context.Receipts
      .Include(e => e.Order)
      .ThenInclude(e => e.Items)
      .Include(e => e.Voucher)
      .AsNoTracking()
      .FirstOrDefaultAsync(e => e.OrderId == request.OrderId);

    var workbook = _extractor.ToExcel(e => {
      
    });

    var stream = new MemoryStream();

    workbook.SaveAs(stream);

    return stream;
  }

  // public IActionResult ExportExcel(int orderId)
  //       {
  //           var wb = new XLWorkbook();
  //           var ws = wb.Worksheets.Add("Receipt");

  //           ws.Cell("A1").Value = "OrderId";
  //           ws.Cell("B1").Value = "Seller";
  //           ws.Cell("C1").Value = "Total";
  //           ws.Cell("D1").Value = "Description";
  //           ws.Cell("E1").Value = "AddressId";
  //           ws.Cell("F1").Value = "Voucher";
  //           ws.Cell("G1").Value = "Status";

  //           var lst = _receiptForExcel.GetReciptForExcel(orderId);
  //           int row = 2;

  //           for (int i = 0; i < lst.Count; i++)
  //           {
  //               ws.Cell("A1" + row).Value = lst[i].OrderId;
  //               ws.Cell("B1" + row).Value = lst[i].Seller;
  //               ws.Cell("C1" + row).Value = lst[i].Total;
  //               ws.Cell("D1" + row).Value = lst[i].Description;
  //               ws.Cell("E1" + row).Value = lst[i].AddressId;
  //               ws.Cell("F1" + row).Value = lst[i].NameVoucher;
  //               ws.Cell("G1" + row).Value = lst[i].Status;
  //               row++;
  //           }

  //           string nameFile = "Export_" + DateTime.Now.Ticks + ".xlsx";
  //           //string pathFile = Server.MapPath("~/Resource/ExportExcel" + nameFile);

  //           //wb.SaveAs(pathFile);

  //           return Ok(nameFile);
  //       }

  //       #endregion
  //   }
}