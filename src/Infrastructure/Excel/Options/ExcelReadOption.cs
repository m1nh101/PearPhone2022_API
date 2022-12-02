namespace Infrastructure.Excel.Options;

public class ExcelReadOption
{
    public int RowStart { get; set; } = 1;
    public int ColumnStart { get; set; } = 1;
    public int WorkSheet { get; set; } = 1;
}
