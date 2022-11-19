using Core.CQRS.Sales.Add;
using Core.CQRS.Sales.Get;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/sales")]
    [ApiController]
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
    }
}
