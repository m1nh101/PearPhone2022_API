using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Cart.Remove;

public sealed class RemoveItemFromCartRequestHandler
  : IRequestHandler<RemoveItemFromCartRequest, ActionResponse>
{
  public Task<ActionResponse> Handle(RemoveItemFromCartRequest request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
