using Core.Model;

namespace Core.Interfaces;

public interface IReceiptForExcel
{
    List<ExcelModel> GetReciptForExcel (int oderId);
}