using Core.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Database;

public static class DatabaseMigration
{
  public static IServiceCollection Migration(this IServiceCollection services)
  {
    var context = services.BuildServiceProvider().GetRequiredService<AppDbContext>();

    if (!context.Database.CanConnect())
    {
      context.Database.Migrate();

      //insert default admin and role to db
      GenerateDefaultRoleAndAdminUser(services);
    }

    return services;
  }

  private static void GenerateDefaultRoleAndAdminUser(IServiceCollection services)
  {
    UserManager<User> _userManager = services.BuildServiceProvider().GetRequiredService<UserManager<User>>();
    RoleManager<IdentityRole> _roleManager = services.BuildServiceProvider().GetRequiredService<RoleManager<IdentityRole>>();

    User user = new()
    {
      UserName = "admin",
      FirstName = "Admin",
      LastName = "Root"
    };

    IdentityRole role = new("admin");

    Task.Run(async () =>
    {
      await _userManager.CreateAsync(user, "admin@1234");
      await _roleManager.CreateAsync(role);
      await _userManager.AddToRoleAsync(user, "admin");
    });
  }
}