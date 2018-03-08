using System.Collections.Generic;

namespace Akentas.Mailer
{
    public class EmailSender
    {
        private readonly string _messagesTemplatesRootPath;

        public EmailSender(string messagesTemplatesRootPath)
        {
            _messagesTemplatesRootPath = messagesTemplatesRootPath;
        }
        
        public void SendEmail(string from, string to, string bcc, string subject, string templateName, Dictionary<string, string> placeholdersWithValues)
        {
            var messageTemplateReader = new MessageTemplateReader(_messagesTemplatesRootPath);
            var messageSignatureReader = new MessageSignatureReader(messageTemplateReader);
            var placeholdersReplacer = new PlaceholdersReplacer();
            var messageBodyCreator = new MessageBodyCreator(messageTemplateReader, messageSignatureReader, placeholdersReplacer);
            var smtpClientWrapper = new SmtpClientWrapper();
            var mailSender = new MessageSender(messageBodyCreator, smtpClientWrapper);

            mailSender.Send(from, to, bcc, subject, templateName, placeholdersWithValues);
        }
    }
}