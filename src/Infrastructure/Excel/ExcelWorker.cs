using ClosedXML.Excel;
using Infrastructure.Excel.Options;

namespace Infrastructure.Excel;

public class ExcelWorker
{
    private readonly ExcelReadOption _option;

    public ExcelWorker(ExcelReadOption option)
    {
      if(option == null)
        throw new ArgumentNullException(nameof(option), "option cannot not null");

      _option = option;
    }

    public IEnumerable<TDestination> ParseExcelToData<TDestination>(Func<IXLRow, TDestination> parser,
      IEnumerable<MemoryStream> streams)
    {
      var records = new List<TDestination>();

      foreach(var stream in streams)
      {
        using var workbook = new XLWorkbook(stream);

        var worksheet = workbook.Worksheet(_option.WorkSheet);
        var lastRowUsed = worksheet.LastRowUsed().RowNumber();
        var rows = worksheet.Rows(_option.RowStart, lastRowUsed);

        foreach(var row in rows)
        {
          var record = parser(row);

          records.Add(record);
        }
      }

      return records;
    }
}