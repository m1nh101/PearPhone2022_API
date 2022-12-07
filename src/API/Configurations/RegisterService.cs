using Core.Entities.Payments;
using Core.Interfaces;
using Infrastructure.Email;
using Infrastructure.Excel;
using Infrastructure.Excel.Client;
using Infrastructure.Palpal;

namespace API.Configurations;

public static class RegisterService
{
  public static IServiceCollection AddServiceToContainter(this IServiceCollection services)
  {
    services.AddTransient<IEmailSender, SendEmail>();

    services.AddScoped<IClient<IEnumerable<MemoryStream>, Voucher>, VoucherClient>();

    services.AddScoped<ICheckout, Checkout>();
    services.AddScoped<IExcelExtractor, ExcelWorker>();

    return services;
  }
}
