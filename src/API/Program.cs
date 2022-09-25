using API.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.DbConfiguration(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();