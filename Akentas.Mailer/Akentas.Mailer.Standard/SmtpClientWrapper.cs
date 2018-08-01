using System.Net.Mail;

namespace Akentas.Mailer
{
    public class SmtpClientWrapper : ISmtpClientWrapper
    {
        public void Send(MailMessage mailMessage)
        {
            new SmtpClient().Send(mailMessage);
        }
    }
}