using ClosedXML.Excel;

namespace Core.Interfaces;

public interface IExcelExtractor
{
  XLWorkbook ToExcel(Action<IXLWorksheet> parser);
}