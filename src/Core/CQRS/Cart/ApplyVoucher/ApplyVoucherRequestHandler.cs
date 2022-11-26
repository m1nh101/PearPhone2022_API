using Core.Entities.Payments;
using Core.Helpers;
using Core.Helpers.Extensions;
using Core.Interfaces;
using Core.Specifications;
using MediatR;

namespace Core.CQRS.Cart.ApplyVoucher;

public sealed class ApplyVoucherRequestHandler
  : IRequestHandler<ApplyVoucherRequest, ActionResponse>
{
  private readonly IAppDbContext _context;
  private readonly ICurrentUser _user;

  public ApplyVoucherRequestHandler(IAppDbContext context, ICurrentUser user)
  {
    _context = context;
    _user = user;
  }

  public async Task<ActionResponse> Handle(ApplyVoucherRequest request, CancellationToken cancellationToken)
  {
    var order = await _context.Orders.CurrentOrder(_user.Id);

    Receipt? receipt = order.Receipt;

    if(receipt == null)
      receipt = order.MakeReceipt();

    var voucher = Query.Get(_context.Vouchers, new VoucherDetailSpecification(request.Code), false);

    var discount = receipt.ApplyVoucher(voucher);

    _context.Orders.Update(order);

    await _context.Commit();

    var data = new ApplyVoucherResponse(discount, receipt.Total);

    return new ActionResponse(System.Net.HttpStatusCode.OK, "Ok").WithData(data);
  }
}