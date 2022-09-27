namespace API.Configurations;

public static class CookieConfiguration
{
  public static IServiceCollection ConfigureCookies(this IServiceCollection services)
  {
    services.AddCookiePolicy(options =>
    {
      options.HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always;
      options.Secure = CookieSecurePolicy.Always;
      options.MinimumSameSitePolicy = SameSiteMode.None;
    });

    return services;
  }
}