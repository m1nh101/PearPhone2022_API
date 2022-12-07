using Core.Model;

namespace Core.Interfaces;

public interface IReceiptForExcel
{
    List<ExcelModel> GetReceiptForExcel (int oderId);
}