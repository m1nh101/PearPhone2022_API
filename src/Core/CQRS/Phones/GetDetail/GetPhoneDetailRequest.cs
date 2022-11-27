using Core.Helpers;
using Core.Interfaces;
using Core.Specifications;
using MediatR;

namespace Core.CQRS.Phones.GetDetail;

public sealed record GetPhoneDetailRequest(
  int Id
) : IRequest<ActionResponse>;

public sealed class GetPhoneDetailRequestHandler
  : IRequestHandler<GetPhoneDetailRequest, ActionResponse>
{
  private readonly IAppDbContext _context;

  public GetPhoneDetailRequestHandler(IAppDbContext context)
  {
    _context = context;
  }

  public Task<ActionResponse> Handle(GetPhoneDetailRequest request, CancellationToken cancellationToken)
  {
    var phone = Query.Get(_context.Phones, new PhoneSpecification(request.Id), false);

    return Task.FromResult(new ActionResponse(System.Net.HttpStatusCode.OK, "Ok"));
  }
}