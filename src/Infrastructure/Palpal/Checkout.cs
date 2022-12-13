using Core.Interfaces;
using Microsoft.Extensions.Configuration;
using PayPal.Core;
using PayPal.v1.Payments;

namespace Infrastructure.Palpal;

public class Checkout : ICheckout
{
  private const double _usd = 24938;
  private const string _host = "https://localhost:7236";
  private readonly SandboxEnvironment _env;

  public Checkout(IConfiguration configuration)
  {
    _env = new(configuration["PaypalSettings:clientId"], configuration["PaypalSettings:secretKey"]);
  }

  public async Task<string> Process(Core.Entities.Orders.Order order, Core.Entities.Users.ShippingAddress address)
  {
    var client = new PayPalHttpClient(_env);

    var payload = MakePayment(order, address);

    var request = new PaymentCreateRequest()
      .RequestBody(payload);

    var response = await client.Execute(request);

    var result = response.Result<Payment>();

    foreach (var url in result.Links)
      if (url.Rel.ToLower().Trim().Equals("approval_url"))
        return url.Href;

    return string.Empty;
  }

  private static Payment MakePayment(Core.Entities.Orders.Order order, Core.Entities.Users.ShippingAddress address)
  {
    long now = DateTime.Now.Ticks;

    var total = Math.Round(order.Total / _usd, 2);

    var transactions = new List<Transaction>()
    {
      new Transaction
      {
        Amount = new Amount
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
        ItemList = new ItemList
        {
          Items = order.Items.Select(e => new Item
          {
            Name = e.Stock.Phone.Name,
            Currency = "USD",
            Price = Math.Round(e.Price / _usd, 2).ToString(),
            Quantity = e.Quantity.ToString(),
            Sku = "sku",
            Tax = "0"
          }).ToList(),
          ShippingAddress = new ShippingAddress
          {
            Line1 = address.Address,
            CountryCode = "VN",
            City = address.City
          }
        },
        Description = $"Invoice #{now}",
        InvoiceNumber = now.ToString(),
      },
    };

    return new Payment
    {
      Intent = "sale",
      Transactions = transactions,
      RedirectUrls = new RedirectUrls()
      {
        CancelUrl = $"{_host}/Order/CheckoutFail",
        ReturnUrl = $"{_host}/Order/CheckoutSuccess"
      },
      Payer = new Payer()
      {
        PaymentMethod = "paypal"
      },
    };
  }
}