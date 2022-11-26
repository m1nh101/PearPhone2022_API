using Core.CQRS.Auth.UpdatePassword;
using Core.CQRS.ShippingAddresses.Add;
using Core.CQRS.ShippingAddresses.Delete;
using Core.CQRS.ShippingAddresses.Get;
using Core.CQRS.ShippingAddresses.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/users")]
[Authorize(Roles = "customer")]
public class UserController : ControllerBase
{
  private readonly IMediator _mediator;

  public UserController(IMediator mediator)
  {
    _mediator = mediator;
  }

  #region Shipping Address

  [HttpGet]
  [Route("addresses")]
  public async Task<IActionResult> GetShippingAddresses()
  {
    var request = new GetShippingAddressRequest();
    var response = await _mediator.Send(request);
    return Ok(response);
  }

  [HttpPost]
  [Route("addresses")]
  public async Task<IActionResult> AddNewShippingAddress([FromBody] AddShippingAddressRequest request)
  {
    var response = await _mediator.Send(request);
    return Ok(response);
  }

  [HttpPatch]
  [Route("addresses/{id:int}")]
  public async Task<IActionResult> UpdateShippingAddress([FromQuery] int id,
    [FromBody] UpdateShippingAddressRequest request)
  {
    var response = await _mediator.Send(request);
    return Ok(response);
  }

  [HttpDelete]
  [Route("addresses/{id:int}")]
  public async Task<IActionResult> RemoveShippingAddress([FromRoute] int id)
  {
    var request = new RemoveShippingAddressRequest(id);
    var response = await _mediator.Send(request);
    return Ok(response);
  }
  #endregion

  [HttpPost]
  [Route("update-password")]
  public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordRequest request)
  {
    var response = await _mediator.Send(request);
    return Ok(response);
  }
}
