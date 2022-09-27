using Microsoft.AspNetCore.Identity;

namespace Core.Validators.Customize;

public class AuthErrorDescriber : IdentityErrorDescriber
{
  public override IdentityError DuplicateEmail(string email)
  {
    var error = base.DuplicateEmail(email);

    error.Description = $"Email {email} đã được sử dụng.";

    return error;
  }

  public override IdentityError DuplicateUserName(string userName)
  {
    var error = base.DuplicateUserName(userName);

    error.Description = $"Tên đăng nhập {userName} đã được sủ dụng";

    return error;
  }

  public override IdentityError PasswordTooShort(int length)
  {
    var error = base.PasswordTooShort(length);

    error.Description = $"Độ dài mật khẩu tối thiểu phải bằng {length}";

    return error;
  }

  public override IdentityError PasswordMismatch()
  {
    var error = base.PasswordMismatch();

    error.Description = "Mật khẩu nhắc lại không khớp";

    return error;
  }

  public override IdentityError InvalidEmail(string email)
  {
    var error = base.InvalidEmail(email);

    error.Description = $"Email {email} không hợp lệ";

    return error;
  }
}