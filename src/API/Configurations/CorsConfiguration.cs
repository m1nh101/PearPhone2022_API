namespace API.Configurations;

public static class CorsConfiguration
{
  public static IServiceCollection ConfigureCors(this IServiceCollection services)
  {
    services.AddCors(options =>
    {
      options.AddPolicy("cors", policy =>
      {
        policy.AllowAnyHeader()
          .WithMethods("POST", "GET", "PUT", "PATCH", "DELETE")
          .AllowAnyOrigin();
      });
    });

    return services;
  }
}