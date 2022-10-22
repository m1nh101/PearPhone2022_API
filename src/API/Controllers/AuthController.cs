using Core.CQRS.Auth.Login;
using Core.CQRS.Auth.Register;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
  private readonly IMediator _mediator;

  public AuthController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpPost]
  [Route("register")]
  public async Task<IActionResult> Register([FromBody] RegisterRequest register)
  {
    var response = await _mediator.Send(register);
    if(response.StatusCode == System.Net.HttpStatusCode.OK)
      return Ok(response);
    return BadRequest(response);
  }

  [HttpPost]
  [Route("login")]
  public async Task<IActionResult> Login([FromBody] LoginRequest request)
  {
    var response = await _mediator.Send(request);

    if(response.StatusCode == System.Net.HttpStatusCode.OK)
    {
      var data = (SuccessLoginResponse) response.Data!;
      Response.Cookies.Append("token", data.Token);
      return Ok(response);
    }

    return Unauthorized(response);
  }

  [HttpPost]
  [Route("logout")]
  [Authorize]
  public IActionResult Logout()
  {
    Response.Cookies.Delete("token");
    return NoContent();
  }
}