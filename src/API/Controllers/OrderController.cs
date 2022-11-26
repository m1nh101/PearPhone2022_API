using BraintreeHttp;
using Core.CQRS.Cart.Add;
using Core.CQRS.Cart.ApplyVoucher;
using Core.CQRS.Cart.Checkout;
using Core.CQRS.Cart.Get;
using Core.CQRS.Cart.Remove;
using Core.CQRS.Cart.Update;
using Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PayPal.Core;
using PayPal.v1.Payments;


namespace API.Controllers;

[ApiController]
[Route("api/orders")]
[Authorize(Roles = "customer")]
public class OrderController : ControllerBase
{
	private readonly IMediator _mediator;
    private readonly IAppDbContext _appDbContext;
    private readonly string _clientId;
    private readonly string _secretKey;
    public double UsdRate = 24938;//store in Database

    public OrderController(IMediator mediator, IConfiguration configuration)
    {
        _mediator = mediator;
        _clientId = configuration["PaypalSettings:clientId"];
        _secretKey = configuration["PaypalSettings:secretKey"];
    }

	[HttpGet]
	public async Task<IActionResult> GetOrder()
	{
		var request = new GetCurrentOrderRequest();
		var response = await _mediator.Send(request);
		return Ok(response);
	}

	[HttpPost]
	public async Task<IActionResult> AddItem([FromBody] AddItemToCartRequest request)
	{
		var response = await _mediator.Send(request);
		return Ok(response);
	}

	[HttpPatch]
	[Route("{productId:int}")]
	public async Task<IActionResult> UpdateItem([FromRoute] int productId,
		[FromBody] UpdateItemQuantityRequest request)
	{
		var response = await _mediator.Send(request);
		return Ok(response);
	}

	[HttpDelete]
	[Route("{productId:int}")]
	public async Task<IActionResult> RemoveItem([FromRoute] int productId,
		[FromBody] RemoveItemFromCartRequest request)
	{
		var response = await _mediator.Send(request);
		return Ok(response);
	}

	[HttpPost]
	[Route("apply")]
	public async Task<IActionResult> ApplyVoucher([FromQuery] string code)
	{
		var request = new ApplyVoucherRequest(code);
		var response = await _mediator.Send(request);
		return Ok(response);
	}

    #region Paypal checkout

    [Authorize, HttpPost]
    [Route("checkoutPaypal")]
    public async Task<IActionResult> PaypalCheckOut()
    {
        var request = new CheckoutWithPaypalRequest();
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    #endregion


}
