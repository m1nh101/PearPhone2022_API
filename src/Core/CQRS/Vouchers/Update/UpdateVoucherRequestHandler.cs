using AutoMapper;
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

    _mapper.Map(request, voucher);

    _context.Vouchers.Update(voucher);

    await _context.Commit();

    return new ActionResponse(System.Net.HttpStatusCode.OK, "Thay đổi thành công")
      .WithData(request);
  }
}
