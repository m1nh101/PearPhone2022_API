using System.Net;
using BraintreeHttp;
using Core.Helpers.Extensions;
using Core.Interfaces;
using MediatR;
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
using Microsoft.Extensions.Configuration;
using PayPal.Core;
using PayPal.v1.Payments;

namespace Core.CQRS.Cart.Checkout;

public class CheckoutWithPaypalRequestHandle:IRequestHandler<CheckoutWithPaypalRequest, ActionResponse>
{
    private readonly IAppDbContext _appDbContext;
    private readonly ICurrentUser _currentUser;
    private readonly string _clientId;
    private readonly string _secretKey;
    public double UsdRate = 24938;//store in Database

    public CheckoutWithPaypalRequestHandle(IAppDbContext appDbContext, ICurrentUser currentUser, IConfiguration configuration)
    {
        _appDbContext = appDbContext;
        _currentUser = currentUser;
        _clientId = configuration["PaypalSettings:clientId"];
        _secretKey = configuration["PaypalSettings:secretKey"];
    }

    public async Task<ActionResponse> Handle(CheckoutWithPaypalRequest request, CancellationToken cancellationToken)
    {
        var cart = await _appDbContext.Orders.CurrentOrder(_currentUser.Id);
       
        var environment = new SandboxEnvironment(_clientId, _secretKey);
        var client = new PayPalHttpClient(environment);
        #region Create Paypal Order
        var itemList = new ItemList()
        {
            Items = new List<Item>()
        };
        var total = Math.Round(cart.Total / UsdRate, 2);
        foreach (var item in cart.Items)
        {
            itemList.Items.Add(new Item()
            {
                Name = "Sản phẩm",
                Currency = "USD",
                Price = Math.Round(item.Price / UsdRate, 2).ToString(),
                Quantity = item.Quantity.ToString(),
                Sku = "sku",
                Tax = "0"
            });
        }
        #endregion
        var paypalOrderId = DateTime.Now.Ticks;
        var hostname = $"Https://localhost:7236";
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
        PaymentCreateRequest Paupalrequest = new PaymentCreateRequest();
        Paupalrequest.RequestBody(payment);
        try
        {
            var response = await client.Execute(Paupalrequest);
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
        }
        catch (HttpException httpException)
        {
            var statusCode = httpException.StatusCode;
            var debugId = httpException.Headers.GetValues("PayPal-Debug-Id").FirstOrDefault();
        }

        return new ActionResponse(HttpStatusCode.OK, string.Empty, null, null);
    }
}