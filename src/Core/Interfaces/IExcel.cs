using ClosedXML.Excel;

namespace Core.Interfaces;

public interface IExcelExtractor
{
  XLWorkbook ToExcel<TSource>(TSource source, Action<IXLWorksheet, TSource> parser);
}