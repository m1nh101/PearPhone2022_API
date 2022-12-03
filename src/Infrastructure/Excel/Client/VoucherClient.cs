using Core.Entities.Payments;
using Core.Interfaces;
using Infrastructure.Database.Extensions;

namespace Infrastructure.Excel.Client;

public class VoucherClient : IClient<IEnumerable<MemoryStream>, Voucher>
{
  private readonly IAppDbContext _context;

  public VoucherClient(IAppDbContext context)
  {
    _context = context;
  }

  public async Task<ActionResponse> Invoke(IEnumerable<MemoryStream> streams)
  {
    var recordImported = await _context.Vouchers.Import(streams);

    await _context.Commit();

    return new ActionResponse(System.Net.HttpStatusCode.OK, "Ok")
      .WithData(new { Imported = recordImported });
  }
}
