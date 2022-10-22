using Core.Entities.Users;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Core.Helpers;

public class JwtHelper : IJwtHelper
{
  private readonly UserManager<User> _userManager;
  private readonly IConfiguration _configuration;

  public JwtHelper(UserManager<User> userManager,
    IConfiguration configuration)
  {
    _userManager = userManager;
    _configuration = configuration;
  }

  private User _user = User.Empty();

  public void SetUser(User user)
  {
    _user = user;
  }

  private Claim GetUsernameClaim() => new(ClaimTypes.Name, _user.UserName);
  private Claim GetEmailClaim() => new(ClaimTypes.Email, _user.Email);
  private Claim GetNameClaim() => new(ClaimTypes.GivenName, _user.GetFullName());
  private Claim GetUserIdClaim() => new(ClaimTypes.NameIdentifier, _user.Id);
  private async Task<IEnumerable<Claim>> GetRoleClaim()
  {
    IEnumerable<string> roles = await _userManager.GetRolesAsync(_user);
    return roles.Select(e => new Claim(ClaimTypes.Role, e))
      .AsEnumerable();
  }

  private async Task<ClaimsIdentity> GetClaimsIdentity()
  {
    var claims = new List<Claim>()
    {
      GetEmailClaim(),
      GetUserIdClaim(),
      GetUsernameClaim(),
      GetNameClaim()
    }.Union(await GetRoleClaim());

    return new ClaimsIdentity(claims);
  }

  public async Task<string> GenerateJwtToken()
  {
    var tokenHandler = new JwtSecurityTokenHandler();
    var secretTokenKey = Encoding.UTF8.GetBytes(_configuration["JWT_SECRET"]);
    var tokenEffectiveDays = Convert.ToInt32(_configuration["JWT_EFFECTIVE_DAYS"]);
    var symmetricKey = new SymmetricSecurityKey(secretTokenKey);

    var tokenDescriptor = new SecurityTokenDescriptor
    {
      Subject = await GetClaimsIdentity(),
      Expires = DateTime.UtcNow.AddDays(tokenEffectiveDays),
      SigningCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256)
    };

    var token = tokenHandler.CreateToken(tokenDescriptor);
    
    return tokenHandler.WriteToken(token);
  }
}