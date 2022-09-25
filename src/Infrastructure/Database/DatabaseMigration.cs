using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Database;


public static class DatabaseMigration
{
  public static IApplicationBuilder Migration(this IApplicationBuilder app,
    IServiceCollection services,
    IConfiguration configuration)
  {
    string runningMode = configuration["Mode"] ?? "Local";

    if (runningMode.Equals("Local"))
      return app;

    var context = services.BuildServiceProvider().GetRequiredService<AppDbContext>();

    if (!context.Orders.Any())
      context.Database.Migrate();

    return app;
  }
}