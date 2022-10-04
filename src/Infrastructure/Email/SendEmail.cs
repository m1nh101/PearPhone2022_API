using Core.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Infrastructure.Email;

public class SendEmail : IEmailSender
{
  private readonly IConfiguration _configuration;

  public SendEmail(IConfiguration configuration)
  {
    _configuration = configuration;
  }

  public Task Send(string to, string subject, string content)
  {
    var user = _configuration["GMAIL:UID"];
    var password = _configuration["GMAIL:PWD"];
    var client = new SmtpClient("smtp.gmail.com");
    var mail = new MailMessage
    {
      From = new MailAddress(user)
    };
    mail.To.Add(to);
    mail.Subject = subject;
    mail.IsBodyHtml = true;
    mail.Body = content;
    mail.Priority = MailPriority.High;

    client.Port = 587;
    client.Credentials = new NetworkCredential(user, password);
    client.EnableSsl = true;
    client.Send(mail);

    return Task.CompletedTask;
  }
}