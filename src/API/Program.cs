using API.Configurations;
using Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureCookies();

builder.Services.ConfigureCors(builder.Configuration);

builder.Services.ConfigureIdentity();

builder.Services.ConfigureDatabase(builder.Configuration);

builder.Services.ConfigureCoreServices();

builder.Services.ConfigureAuthentication(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors();

app.UseCookiePolicy();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();