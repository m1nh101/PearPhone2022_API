namespace Core.Exceptions;

public class OutOfUseException : Exception
{
  public OutOfUseException(string message): base(message)
  {
  }
}

public class VoucherExpiredException : Exception
{
  public VoucherExpiredException(string message): base(message)
  {
  }
}

public class InvalidVoucherException : Exception
{
  public InvalidVoucherException(string message): base(message)
  {
  }
}