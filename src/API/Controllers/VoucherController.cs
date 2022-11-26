using Core.CQRS.Vouchers.Create;
using Core.CQRS.Vouchers.Delete;
using Core.CQRS.Vouchers.Get;
using Core.CQRS.Vouchers.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/vouchers")]
[Authorize(Roles = "admin")]
public class VoucherController : ControllerBase
{
  private readonly IMediator _mediator;

  public VoucherController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpGet]
  public async Task<IActionResult> Get()
  {
    var request = new GetVouchersRequest();
    var response = await _mediator.Send(request);
    return Ok(response);
  }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] CreateVoucherRequest request)
  {
    var response = await _mediator.Send(request);
    return Ok(response);
  }

  [HttpPatch]
  [Route("{id:int}")]
  public async Task<IActionResult> Update([FromRoute] int id,
    [FromBody] UpdateVoucherRequest request)
  {
    var response = await _mediator.Send(request);
    return Ok(response);
  }

  [HttpDelete]
  [Route("{id:int}")]
  public async Task<IActionResult> Delete([FromRoute] int id)
  {
    var request = new DeleteVoucherRequest(id);
    var response = await _mediator.Send(request);
    return Ok(response);
  }
}
