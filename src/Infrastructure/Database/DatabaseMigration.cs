using Core.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Database;

public static class DatabaseMigration
{
  public static IServiceCollection Migration(this IServiceCollection services, IConfiguration configuration)
  {
    var context = services.BuildServiceProvider().GetRequiredService<AppDbContext>();

    var pendingMigrations = context.Database.GetPendingMigrations();

    if (pendingMigrations.Any())
    {
      context.Database.Migrate();
      MigrateDefaultRoleAndAdminUserToDb(services, configuration);
    }  

    return services;
  }

  private static void MigrateDefaultRoleAndAdminUserToDb(IServiceCollection services, IConfiguration configuration)
  {
    UserManager<User> _userManager = services.BuildServiceProvider().GetRequiredService<UserManager<User>>();
    RoleManager<IdentityRole> _roleManager = services.BuildServiceProvider().GetRequiredService<RoleManager<IdentityRole>>();

    if (!_userManager.Users.Any())
    {
      string rootUsername = configuration["root"] ?? "admin";
      string rootPassword = configuration["rootPwd"] ?? "admin@1234";
      const string adminRoleName = "admin";

      User user = new()
      {
        UserName = rootUsername,
        FirstName = "Admin",
        LastName = "Root"
      };

      IdentityRole role = new(adminRoleName);

      Task.Run(async () =>
      {
        await _userManager.CreateAsync(user, rootPassword);
        await _roleManager.CreateAsync(role);
        await _userManager.AddToRoleAsync(user, adminRoleName);
      });
    }
  }
}