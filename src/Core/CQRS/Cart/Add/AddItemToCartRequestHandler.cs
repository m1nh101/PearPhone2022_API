using Core.Interfaces;
using MediatR;

namespace Core.CQRS.Cart.Add;

public sealed class AddItemToCartRequestHandler
  : IRequestHandler<AddItemToCartRequest, ActionResponse>
{
	private readonly IAppDbContext _context;

  public AddItemToCartRequestHandler(IAppDbContext context)
  {
    _context = context;
  }

  public Task<ActionResponse> Handle(AddItemToCartRequest request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}