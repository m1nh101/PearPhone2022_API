using Core.Comparers;
using Core.Entities.Payments;
using Infrastructure.Excel;
using Infrastructure.Excel.Options;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Extensions;

public static class VoucherDbExtension
{
  public static async Task<int> Import(this DbSet<Voucher> sources, IEnumerable<MemoryStream> streams)
  {
    var excelWorker = new ExcelWorker(e => 
    {
      e.RowStart = 3;
    });

    var data = excelWorker.ParseExcelToData(ParserConfig.VoucherParser, streams);

    //remove duplicate data base on code and voucher type
    data = data.Distinct(new VoucherComparer());

    await sources.AddRangeAsync(data);

    return data.Count();
  }
}