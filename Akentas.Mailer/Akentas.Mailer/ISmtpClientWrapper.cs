using System.Net.Mail;

namespace Akentas.Mailer
{
    public interface ISmtpClientWrapper
    {
        void Send(MailMessage mailMessage);
    }
}