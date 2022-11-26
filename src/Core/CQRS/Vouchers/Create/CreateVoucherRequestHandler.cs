using AutoMapper;
using Core.Entities.Payments;
using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Vouchers.Create;

public sealed class CreateVoucherRequestHandler
  : IRequestHandler<CreateVoucherRequest, ActionResponse>
{
  private readonly IAppDbContext _context;
  private readonly IMapper _mapper;

  public CreateVoucherRequestHandler(IAppDbContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  public async Task<ActionResponse> Handle(CreateVoucherRequest request, CancellationToken cancellationToken)
  {
    var voucher = new Voucher(request.Name, request.EffectiveDate, request.ExpiredDate, request.TimesUse, request.Type);

    await _context.Vouchers.AddAsync(voucher, cancellationToken);

    await _context.Commit();

    var data = _mapper.Map<CreatedVoucherResponse>(voucher);

    return new ActionResponse(System.Net.HttpStatusCode.OK, "Tạo voucher thành công")
      .WithData(data);
  }
}
