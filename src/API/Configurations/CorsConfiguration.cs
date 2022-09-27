namespace API.Configurations;

public static class CorsConfiguration
{
  public static IServiceCollection ConfigureCors(this IServiceCollection services, IConfiguration configuration)
  {
    string clientOrigin = configuration["CLIENT_ORIGIN"] ?? string.Empty;

    services.AddCors(options =>
    {
      options.AddPolicy("cors", policy =>
      {
        policy.AllowAnyHeader()
          .WithMethods("POST", "GET", "PUT", "PATCH", "DELETE")
          .WithOrigins(clientOrigin)
          .AllowCredentials();
      });
    });

    return services;
  }
}