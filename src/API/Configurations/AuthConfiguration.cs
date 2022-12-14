using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API.Configurations;

public static class AuthConfiguration
{
  public static IServiceCollection ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddAuthentication(options =>
    {
      options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
      options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
      options.RequireHttpsMetadata = false;
      options.SaveToken = true;
      options.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        ValidateIssuer = false,
        ValidateAudience = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT_SECRET"]))
      };
      options.Events = new JwtBearerEvents
      {
        OnMessageReceived = (context) =>
        {
          string token = context.Request.Cookies["token"] ?? string.Empty;

          if (!string.IsNullOrEmpty(token))
            context.Token = token;

          return Task.CompletedTask;
        }
      };
    });

    return services;
  }
}