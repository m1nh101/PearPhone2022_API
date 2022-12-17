using Core.CQRS.Sales.Add;
using Core.CQRS.Sales.Get;
using Core.CQRS.Sales.Remove;
using Core.CQRS.Sales.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/sales")]
[ApiController]
[Authorize(Roles = "admin")]
public class SaleController : ControllerBase
{
  private readonly IMediator _mediator;

  public SaleController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpGet]
  public async Task<IActionResult> GetSale()
  {
		var request = new GetListSaleRequest();
    var response = await _mediator.Send(request);
    return Ok(response);
  }

  [HttpPost]
  public async Task<IActionResult> AddSale([FromBody] AddSaleRequest request)
  {
    var response = await _mediator.Send(request);
    return Ok(response);
  }

  [HttpPut("{id:int}")]
  public async Task<IActionResult> UpdateSale([FromBody] UpdateSaleRequest request, int id)
  {
    var response = await _mediator.Send(request);
    return Ok(response);
  }

  [HttpDelete("{id:int}")]
  public async Task<IActionResult> DeleteSale([FromRoute] int id)
  {
		var request = new RemoveSaleRequest(id);
    var response = await _mediator.Send(request);
    return Ok(response);
  }
}