using AutoMapper;
using Core.CQRS.Vouchers.Create;
using Core.Entities.Payments;
using Core.Helpers;
using Core.Interfaces;
using Core.Specifications;
using MediatR;

namespace Core.CQRS.Vouchers.Update;

public sealed class UpdateVoucherRequestHandler
  : IRequestHandler<UpdateVoucherRequest, ActionResponse>
{
  private readonly IAppDbContext _context;
  private readonly IMapper _mapper;

  public UpdateVoucherRequestHandler(IAppDbContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  public async Task<ActionResponse> Handle(UpdateVoucherRequest request, CancellationToken cancellationToken)
  {
    var voucher = Query.Get(_context.Vouchers, new VoucherDetailSpecification(request.Id), false);

    var payload = new Voucher(request.Name, request.EffectiveDate, request.ExpiredDate, request.TimesUse, request.Type);

    voucher.Update(payload);

    await _context.Commit();

    return new ActionResponse(System.Net.HttpStatusCode.OK, "Thay đổi thành công")
      .WithData(request);
  }
}
