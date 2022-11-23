using BraintreeHttp;
using Core.CQRS.Cart.Add;
using Core.CQRS.Cart.ApplyVoucher;
using Core.CQRS.Cart.Get;
using Core.CQRS.Cart.Remove;
using Core.CQRS.Cart.Update;
using Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayPal.Core;
using PayPal.v1.Payments;
using HttpClient = BraintreeHttp.HttpClient;


namespace API.Controllers;

[ApiController]
[Route("api/orders")]
[Authorize(Roles = "customer")]
public class OrderController : ControllerBase
{
	private readonly IMediator _mediator;
    private IConfiguration _configuration;
    private readonly IAppDbContext _appDbContext;
    private readonly string _clientId;
    private readonly string _secretKey;
    public double TyGiaUSD = 23300;//store in Database

    public OrderController(IMediator mediator, IConfiguration configuration, IAppDbContext appDbContext)
    {
        _mediator = mediator;
        _configuration = configuration;
        _appDbContext = appDbContext;
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

    public List<GetCurrentOrderResponse> Carts
    {
        get
        {
            var request = new List<GetCurrentOrderResponse>();
            var response =  _mediator.Send(request);
            return request;
        }
    }
    [Authorize, HttpPost]
    [Route("checkout")]
    public async Task<IActionResult> PaypalCheckOut()
    {
        var environment = new SandboxEnvironment(_clientId, _secretKey);
        var client = new PayPalHttpClient(environment);
        #region Create Paypal Order
        var itemList = new ItemList()
        {
            Items = new List<Item>()
        };
        var total = Math.Round(Carts.Sum(p => p.Total) / TyGiaUSD, 2);
        foreach (var item in Carts)
        {
            itemList.Items.Add(new Item()
            {
                //Name = item.Items.ProductName,
                //Currency = "USD",
                //Price = Math.Round(item.Items.Price / TyGiaUSD, 2).ToString(),
                //Quantity = item.Quantity.ToString(),
                Sku = "sku",
                Tax = "0"
            });
        }
        #endregion
        var paypalOrderId = DateTime.Now.Ticks;
        var hostname = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
        var payment = new Payment()
        {
            Intent = "sale",
            Transactions = new List<Transaction>()
            {
                new Transaction()
                {
                    Amount = new Amount()
                    {
                        Total = total.ToString(),
                        Currency = "USD",
                        Details = new AmountDetails
                        {
                            Tax = "0",
                            Shipping = "0",
                            Subtotal = total.ToString()
                        }
                    },
                    ItemList = itemList,
                    Description = $"Invoice #{paypalOrderId}",
                    InvoiceNumber = paypalOrderId.ToString()
                }
            },
            RedirectUrls = new RedirectUrls()
            {
                CancelUrl = $"{hostname}/Order/CheckoutFail",
                ReturnUrl = $"{hostname}/Order/CheckoutSuccess"
            },
            Payer = new Payer()
            {
                PaymentMethod = "paypal"
            }
        };

        PaymentCreateRequest request = new PaymentCreateRequest();
        request.RequestBody(payment);
        try
        {
            var response = await client.Execute(request);
            var statusCode = response.StatusCode;
            Payment result = response.Result<Payment>();

            var links = result.Links.GetEnumerator();
            string paypalRedirectUrl = null;
            while (links.MoveNext())
            {
                LinkDescriptionObject link = links.Current;
                if (link.Rel.ToLower().Trim().Equals("approval_url"))
                {
                    paypalRedirectUrl = link.Href;
                }
            }

            return Redirect(paypalRedirectUrl);
        }
        catch (HttpException httpException)
        {
            var statusCode = httpException.StatusCode;
            var debugId = httpException.Headers.GetValues("PayPal-Debug-Id").FirstOrDefault();
        }
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CheckoutFail()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CheckoutSuccess()
    {
        return Ok();
    }
}
