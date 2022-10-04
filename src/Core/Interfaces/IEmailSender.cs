namespace Core.Interfaces;

public interface IEmailSender
{
  Task Send(string to, string subject, string body);
}