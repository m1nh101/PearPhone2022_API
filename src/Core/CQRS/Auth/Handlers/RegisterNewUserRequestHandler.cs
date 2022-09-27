using AutoMapper;
using Core.CQRS.Auth.Requests;
using Core.CQRS.Auth.Responses;
using Core.Entities.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Core.CQRS.Auth.Handlers;

public class RegisterNewUserRequestHandler : IRequestHandler<RegisterNewUser, CommonResponse<UserResponse>>
{
  private readonly UserManager<User> _userManger;
  private readonly IMapper _mapper;

  public RegisterNewUserRequestHandler(UserManager<User> userManger,
    IMapper mapper)
  {
    _userManger = userManger;
    _mapper = mapper;
  }

  public async Task<CommonResponse<UserResponse>> Handle(RegisterNewUser request, CancellationToken cancellationToken)
  {
    var user = _mapper.Map<User>(request);
    user.SetStatus(true);

    var result = await _userManger.CreateAsync(user, request.Password);

    if (result.Succeeded)
    {
      await _userManger.AddToRoleAsync(user, "customer");

      var dataResponse = _mapper.Map<UserResponse>(user);
      return new CommonResponse<UserResponse>
      {
        Data = dataResponse,
        Message = "Đăng ký thành công",
        StatusCode = System.Net.HttpStatusCode.OK
      };
    }

    return new CommonResponse<UserResponse>
    {
      Data = null,
      Errors = result.Errors,
      Message = "Đăng ký thất bại",
      StatusCode = System.Net.HttpStatusCode.BadRequest
    };
  }
}