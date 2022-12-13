using Core.Helpers;
using Core.Interfaces;
using Core.Specifications;
using MediatR;

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
    var receipt = await Query.Find(_context.Receipts, new ReceiptSpecification(request.OrderId), QueryState.NoTracking);

    var workbook = _extractor.ToExcel(e => {
      e.MergedRanges.Add(e.Row(3).Cell(3));
      e.MergedRanges.Add(e.Row(3).Cell(8));
      e.Row(3).Merge();
      e.Row(3).Cell(3).Value = "Hóa đơn";
      e.Row(4).Cell(3).Value = "";
    });

    var stream = new MemoryStream();

    workbook.SaveAs(stream);

    return stream;
  }
}