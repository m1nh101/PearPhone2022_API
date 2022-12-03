using API.Helpers;
using Core.CQRS.Vouchers.Create;
using Core.CQRS.Vouchers.Delete;
using Core.CQRS.Vouchers.Get;
using Core.CQRS.Vouchers.Update;
using Core.Entities.Payments;
using Core.Interfaces;
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
  private readonly IClient<IEnumerable<MemoryStream>, Voucher> _client;

  public VoucherController(IMediator mediator,
    IClient<IEnumerable<MemoryStream>, Voucher> client)
  {
    _mediator = mediator;
    _client = client;
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

  [HttpPost]
  [Route("excel")]
  public async Task<IActionResult> ImportData([FromForm] IFormFileCollection files)
  {
    var helper = new ExcelHelper(files);

    var filesValidated = helper.CheckFile();

    if(filesValidated["validFiles"].Count() == 0)
      return BadRequest(new { message = "File không hợp lệ", files = files.Select(e => e.FileName)});

    var streams = await helper.ToMemoryStream(filesValidated["validFiles"]);

    var result = await _client.Invoke(streams);

    var response = new ActionResponse(System.Net.HttpStatusCode.OK, "Ok")
      .WithData(result.Data!)
      .WithError(new { message = "File không hợp lệ", files = files.Select(e => e.FileName)});

    return Ok(response);
  }
}