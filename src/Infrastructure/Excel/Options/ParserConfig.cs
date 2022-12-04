using ClosedXML.Excel;
using Core.Entities.Payments;
using Core.Entities.Phones;
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

  public static Phone ParserPhone(IXLRows rows)
  {
    int column = 3;

    var listField = rows.ToArray();

    var branch = listField[0].Cell(column).GetValue<string>();
    var name = listField[1].Cell(column).GetValue<string>();
    var screen = listField[2].Cell(column).GetValue<string>();
    var ram = listField[3].Cell(column).GetValue<int>();
    var cpu = listField[4].Cell(column).GetValue<string>();
    var connection = listField[5].Cell(column).GetValue<string>();
    var pin = listField[6].Cell(column).GetValue<string>();
    var charger = listField[7].Cell(column).GetValue<string>();
    var secure = listField[8].Cell(column).GetValue<string>();
    var audio = listField[9].Cell(column).GetValue<string>();
    var os = listField[10].Cell(column).GetValue<string>();
    var camera = listField[11].Cell(column).GetValue<string>();

    var detail = new PhoneDetail(pin, screen, os, ram, charger, camera, audio, secure, connection);
    
    return new Phone(name, branch, detail);
  }
}
