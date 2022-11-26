using Core.CQRS.ShippingAddresses.Add;
using Core.CQRS.ShippingAddresses.Delete;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/addresses")]
public class ShippingAddressController : ControllerBase
{
  private readonly IMediator _mediator;

  public ShippingAddressController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpPost]
  public async Task<IActionResult> AddNewShippingAddress([FromBody] AddShippingAddressRequest request)
  {
    var response = await _mediator.Send(request);
    return Ok(response);
  }

  [HttpPatch]
  [Route("{id:int}")]
  public async Task<IActionResult> RemoveShippingAddress([FromRoute] int id)
  {
    var request = new RemoveShippingAddressRequest(id);
    var response = await _mediator.Send(request);
    return Ok(response);
  }
}
