using Core.Helpers;
using Core.Interfaces;
using Core.Specifications;
using MediatR;

namespace Core.CQRS.Vouchers.Get;

public sealed class GetVouchersRequestHandler
  : IRequestHandler<GetVouchersRequest, ActionResponse>
{
  private readonly IAppDbContext _context;

  public GetVouchersRequestHandler(IAppDbContext context)
  {
    _context = context;
  }

  public Task<ActionResponse> Handle(GetVouchersRequest request, CancellationToken cancellationToken)
  {
    var data = Query.All(_context.Vouchers, new AllVoucherSpecification(), QueryState.NoTracking)
      .Select(e => new GetVoucheRequestResponse(e.Id, e.Name, e.Code, e.EffectiveDate, e.ExpiredDate, e.TimesRemain));

    var response = new ActionResponse(System.Net.HttpStatusCode.OK, "Thành công")
      .WithData(data);

    return Task.FromResult(response);
  }
}