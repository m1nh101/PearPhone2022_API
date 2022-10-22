using Core.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Database;

public static class DatabaseMigration
{
  public static IServiceCollection Migration(this IServiceCollection services, IConfiguration configuration)
  {
    var context = services.BuildServiceProvider().GetRequiredService<AppDbContext>();

    if((context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator)!.Exists())
    {

      MigrateDefaultRole(services);

      MigrateDefaultAdminUser(services, configuration);
    }

    return services;
  }

  private static void MigrateDefaultRole(IServiceCollection services)
  {
    RoleManager<IdentityRole> _roleManager = services.BuildServiceProvider().GetRequiredService<RoleManager<IdentityRole>>();

    if (!_roleManager.Roles.Any())
    {
      IdentityRole role = new("admin");
      IdentityRole staffRole = new("staff");
      IdentityRole customerRole = new("customer");

      Task.Run(async () =>
      {
        await _roleManager.CreateAsync(role);
        await _roleManager.CreateAsync(staffRole);
        await _roleManager.CreateAsync(customerRole);
      });
    }
  }

  private static void MigrateDefaultAdminUser(IServiceCollection services, IConfiguration configuration)
  {
    UserManager<User> _userManager = services.BuildServiceProvider().GetRequiredService<UserManager<User>>();

    if (!_userManager.Users.Any())
    {
      string rootUsername = configuration["ROOT_CREDENTIAL:UID"] ?? "admin";
      string rootPassword = configuration["ROOT_CREDENTIAL:PWD"] ?? "admin@1234";

      User user = new("Admin", "Root", rootUsername, "admin@admin.com");

      Task.Run(async () =>
      {
        await _userManager.CreateAsync(user, rootPassword);
        await _userManager.AddToRoleAsync(user, "admin");
      });
    }
  }
}