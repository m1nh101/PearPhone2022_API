using Core.Entities.Payments;
using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Vouchers.Create;

public sealed class CreateVoucherRequestHandler
  : IRequestHandler<CreateVoucherRequest, ActionResponse>
{
  private readonly IAppDbContext _context;

  public CreateVoucherRequestHandler(IAppDbContext context)
  {
    _context = context;
  }

  public async Task<ActionResponse> Handle(CreateVoucherRequest request, CancellationToken cancellationToken)
  {
    var voucher = new Voucher(request.Name, request.EffectiveDate, request.ExpiredDate, request.TimesUse, request.Type);

    await _context.Vouchers.AddAsync(voucher, cancellationToken);

    await _context.Commit();

    var data = new CreatedVoucherResponse(voucher.Id, voucher.Name, voucher.TimesRemain,
      voucher.VoucherType, voucher.EffectiveDate, voucher.ExpiredDate);

    return new ActionResponse(System.Net.HttpStatusCode.OK, "Tạo voucher thành công")
      .WithData(data);
  }
}