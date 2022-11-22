using Core.CQRS.Vouchers.Specs;
using Core.Helpers;
using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Vouchers.Delete;

public sealed class DeleteVoucherRequestHandler
  : IRequestHandler<DeleteVoucherRequest, ActionResponse>
{
  private readonly IAppDbContext _context;

  public DeleteVoucherRequestHandler(IAppDbContext context)
  {
    _context = context;
  }

  public async Task<ActionResponse> Handle(DeleteVoucherRequest request, CancellationToken cancellationToken)
  {
    var voucher = Query.Get(_context.Vouchers, new VoucherDetailSpecification(request.Id), false);

    voucher.Delete();

    _context.Vouchers.Update(voucher);

    await _context.Commit();

    return new ActionResponse(System.Net.HttpStatusCode.NoContent, "Xóa thành công", null, null);
  }
}