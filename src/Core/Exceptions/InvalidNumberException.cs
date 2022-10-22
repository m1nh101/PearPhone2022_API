namespace Core.Exceptions;

public sealed class InvalidNumberException : Exception
{
	public InvalidNumberException(string message): base(message)
	{
	}
}