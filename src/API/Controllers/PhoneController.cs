using Core.CQRS.Phones.Add;
using Core.CQRS.Phones.Remove;
using Core.CQRS.Phones.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/phones")]
[ApiController]
[Authorize(Roles = "admin")]
public class PhoneController : ControllerBase
{
  private readonly IMediator _mediator;

  public PhoneController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpGet]
  [AllowAnonymous]
  public async Task<IActionResult> GetPhone([FromBody] GetListPhoneRequest request)
  {
    var response = await _mediator.Send(request);
    return Ok(response);
  }

  [HttpPost]
  public async Task<IActionResult> AddPhone([FromBody] AddNewPhoneRequest request)
  {
    var response = await _mediator.Send(request);
    return Ok(response);
  }

  [HttpPut("{id:int}")]
  public async Task<IActionResult> UpdatePhone([FromBody] UpdateNewPhoneRequest request, int id)
  {
    var response = await _mediator.Send(request);
    return Ok(response);
  }

  [HttpDelete("{id:int}")]
  public async Task<IActionResult> DeletePhone([FromBody] RemoveNewPhoneRequest request, int id)
  {
    var response = await _mediator.Send(request);
    return Ok(response);
  }
}