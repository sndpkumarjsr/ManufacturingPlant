using fINALPROJECTCORE.Signup_Interface;
using fINALPROJECTCORE.Signup_Model;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace fINALPROJECTDATA.Signup_Repository
{
    public class EmailService : IEmailService
    {
        public readonly EmailSettings EmailSettings;
        public EmailService(IOptions<EmailSettings> options)
        {
            this.EmailSettings = options.Value;   
        }

        public void SendEmail(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(EmailSettings.Email);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();

            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                smtp.Connect(EmailSettings.Host, EmailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(EmailSettings.Email, EmailSettings.Password);
                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }

    }
}
