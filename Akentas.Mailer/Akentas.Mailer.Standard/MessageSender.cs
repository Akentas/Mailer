using System.Collections.Generic;
using System.Net.Mail;

namespace Akentas.Mailer
{
    public class MessageSender
    {
        private readonly IMessageBodyCreator _messageBodyCreator;
        private readonly ISmtpClientWrapper _smtpClientWrapper;

        public MessageSender(IMessageBodyCreator messageBodyCreator, ISmtpClientWrapper smtpClientWrapper)
        {
            _messageBodyCreator = messageBodyCreator;
            _smtpClientWrapper = smtpClientWrapper;
        }

        public void Send(string from, string to, string bcc, string subject, string templateName, Dictionary<string, string> placeholdersWithValues)
        {
            var messageBody = _messageBodyCreator.Create(templateName, placeholdersWithValues);
            var mailMessage = new MailMessage(from, to, subject, messageBody);

            if (!string.IsNullOrEmpty(bcc))
            {
                mailMessage.Bcc.Add(bcc);
            }

            _smtpClientWrapper.Send(mailMessage);
        }
    }
}