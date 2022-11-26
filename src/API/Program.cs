using API.Configurations;
using API.Helpers;
using API.Middlewares;
using Core;
using Core.Helpers;
using Core.Interfaces;
using Infrastructure.Email;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureCookies();

builder.Services.ConfigureCors(builder.Configuration);

builder.Services.ConfigureIdentity();

builder.Services.ConfigureDatabase(builder.Configuration);

builder.Services.ConfigureCoreServices();

builder.Services.ConfigureAuthentication(builder.Configuration);

builder.Services.AddTransient<IEmailSender, SendEmail>();

builder.Services.AddControllers();

builder.Services.AddHttpContextAccessor();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

if(app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();

  app.UseSwaggerUI(options =>
  {
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
  });
}

app.UseHttpsRedirection();

app.UseCors("cors");

app.UseCookiePolicy();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<CommonMiddleware>();

app.Run();