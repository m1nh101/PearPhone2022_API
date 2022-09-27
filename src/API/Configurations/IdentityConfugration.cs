using Microsoft.AspNetCore.Identity;

namespace API.Configurations;

public static class IdentityConfugration
{
  public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
  {
    services.Configure<IdentityOptions>(options =>
    {
      options.Password.RequireNonAlphanumeric = false;
      options.Password.RequireUppercase = false;
      options.Password.RequiredLength = 6;
    });

    return services;
  }
}