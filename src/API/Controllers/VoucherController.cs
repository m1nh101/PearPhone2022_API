using Core.CQRS.Vouchers.Create;
using Core.CQRS.Vouchers.Delete;
using Core.CQRS.Vouchers.Get;
using Core.CQRS.Vouchers.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/voucher")]
[Authorize(Roles = "admin")]

public class VoucherController : ControllerBase
{
  private readonly IMediator _mediator;

  public VoucherController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpGet]
  public async Task<IActionResult> GetVouchers()
  {
    var request = new GetVouchersRequest();
    var response = await _mediator.Send(request);
    return Ok(response);
  }

  [HttpPost]
  public async Task<IActionResult> AddPhone([FromBody] CreateVoucherRequest request)
  {
    var response = await _mediator.Send(request);
    return Ok(response);
  }

  [HttpPut("{id:int}")]
  public async Task<IActionResult> UpdatePhone([FromBody] UpdateVoucherRequest request, int id)
  {
    var response = await _mediator.Send(request);
    return Ok(response);
  }

  [HttpDelete("{id:int}")]
  public async Task<IActionResult> DeletePhone([FromRoute] int id)
  {
    var request = new DeleteVoucherRequest(id);
    var response = await _mediator.Send(request);
    return Ok(response);
  }
}