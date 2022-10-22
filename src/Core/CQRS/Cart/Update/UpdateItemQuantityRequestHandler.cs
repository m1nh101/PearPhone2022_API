using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Cart.Update;

public sealed class UpdateItemQuantityRequestHandler
  : IRequestHandler<UpdateItemQuantityRequest, ActionResponse>
{
  public Task<ActionResponse> Handle(UpdateItemQuantityRequest request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
