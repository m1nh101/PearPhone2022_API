using Core.Entities.Phones;
using Core.Interfaces;
using Infrastructure.Excel.Options;

namespace Infrastructure.Excel.Client;

public class PhoneClient : IClient<MemoryStream, Phone>
{
  public Task<ActionResponse> Invoke(MemoryStream param)
  {
    var generalInforWorker = new ExcelWorker(e =>
    {
      e.WorkSheet = 2;
      e.RowStart = 3;
    });

    var stockWorker = new ExcelWorker(e => {
      e.RowStart = 3;
    });

    var phone = generalInforWorker.ParseToData(ParserConfig.ParserPhone, param);

    throw new NotImplementedException();
  }
}