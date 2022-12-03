using ClosedXML.Excel;
using Core.Entities.Payments;
using Shared.Enums;

namespace Infrastructure.Excel.Options;

public static class ParserConfig
{
  public static Voucher VoucherParser(IXLRow row)
  {
    var name = row.Cell(2).GetValue<string>();
    var code = row.Cell(3).GetValue<string>();
    var effectiveDate = row.Cell(4).GetDateTime();
    var expriedDate = row.Cell(5).GetDateTime();
    var timesUse = row.Cell(6).GetValue<int>();
    var type = row.Cell(7).GetValue<int>();

    return new Voucher(name, effectiveDate, expriedDate, timesUse, (VoucherType) type, code);
  }
}
