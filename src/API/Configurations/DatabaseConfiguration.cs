using Core.Entities.Users;
using Core.Validators.Customize;
using Infrastructure.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Configurations;

public static class DatabaseConfiguration
{
  public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddDbContext<AppDbContext>(options =>
    {
      options.UseSqlServer(GetConnection(configuration),
        x => x.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
    });

    services.AddIdentity<User, IdentityRole>()
      .AddDefaultTokenProviders()
      .AddErrorDescriber<AuthErrorDescriber>()
      .AddEntityFrameworkStores<AppDbContext>();

    services.Migration(configuration);

    return services;
  }

  private static string GetConnection(IConfiguration configuration)
  {
    string localDb = configuration.GetConnectionString("LocalDb");

    if (string.IsNullOrEmpty(localDb))
    {
      var server = configuration["SERVER"] ?? "localhost";
      var port = configuration["PORT"] ?? "1433";
      var UID = configuration["UID"] ?? "sa";
      var PWD = configuration["PWD"] ?? string.Empty;
      var database = configuration["DBName"] ?? "PhoneDb";

      return $"Server={server},{port};Database={database};UID={UID};PWD={PWD}";
    }

    return localDb;
  }
}