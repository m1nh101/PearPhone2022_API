using ClosedXML.Excel;
using Core.Interfaces;
using Infrastructure.Excel.Options;

namespace Infrastructure.Excel;

public class ExcelWorker : IExcelExtractor
{
  private readonly ExcelReadOption _option = new ExcelReadOption();

  public ExcelWorker() { }
  public ExcelWorker(Action<ExcelReadOption>? options)
  {
    options?.Invoke(_option);
  }

  public IEnumerable<TDestination> ParseToData<TDestination>(Func<IXLRow, TDestination> parser,
    IEnumerable<MemoryStream> streams)
  {
    var records = new List<TDestination>();

    foreach (var stream in streams)
    {
      using var workbook = new XLWorkbook(stream);

      var worksheet = workbook.Worksheet(_option.WorkSheet);
      var lastRowUsed = worksheet.LastRowUsed().RowNumber();
      var rows = worksheet.Rows(_option.RowStart, lastRowUsed);

      foreach (var row in rows)
      {
        var record = parser(row);

        if (record == null)
          continue;

        records.Add(record);
      }
    }

    return records;
  }

  public TDestination ParseToData<TDestination>(Func<IXLRows, TDestination> parser,
    MemoryStream stream)
  {
    using var workbook = new XLWorkbook(stream);

    var worksheet = workbook.Worksheet(_option.WorkSheet);
    var lastRowUsed = worksheet.LastRowUsed().RowNumber();
    var rows = worksheet.Rows(_option.RowStart, lastRowUsed);

    return parser(rows);
  }

  public XLWorkbook ToExcel(Action<IXLWorksheet> parser)
  {
    var workbook = new XLWorkbook();
    var worksheet = workbook.Worksheets.Add("Hóa đơn");

    parser(worksheet);

    return workbook;
  }
}