using Core.CQRS.Phones.Add;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/phones")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PhoneController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetPhone()
        {
            //var request = new GetListPhoneRequest();
            //var response = await _mediator.Send(request);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddPhone([FromBody] AddNewPhoneRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
