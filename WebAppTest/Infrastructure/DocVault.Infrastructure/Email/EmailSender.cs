using DocVault.Application.Contracts.Email;
using DocVault.Application.Models.Email;
using Microsoft.Extensions.Options;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace DocVault.Infrastructure.Email
{
    public class EmailSender : IEmailSender
    {
        public EmailSettings _emailSettings { get; }
        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public void SendEmail(EmailMessage emailMessage)
        {
            var email = new MimeMessage();

            email.From.Add(new MailboxAddress(_emailSettings.FromName, _emailSettings.FromAddress));
            email.To.Add(MailboxAddress.Parse(emailMessage.To));
            email.Subject = emailMessage.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = emailMessage.Body };

            if (int.TryParse(_emailSettings.Port, out int emailPort) == false)
            {
                emailPort = 587;
            }

            using var smtp = new SmtpClient();
            smtp.Connect(_emailSettings.Host, emailPort, SecureSocketOptions.StartTls);
            smtp.Authenticate(_emailSettings.Username, _emailSettings.Password);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
