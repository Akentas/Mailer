using System.Collections.Generic;
using System.Net.Mail;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Akentas.Mailer.Tests
{
    [TestClass]
    public class MessageSenderTests
    {
        [TestMethod]
        public void MessageSender_Send_Should_SendWelcomeEmail()
        {
            var messageBodyCreatorMock = new Mock<IMessageBodyCreator>();
            var smtpClientMock = new Mock<ISmtpClientWrapper>();
            smtpClientMock.Setup(m => m.Send(It.IsAny<MailMessage>()));

            const string from = "me@testapp.de";
            const string to = "somebody@testapp.de";
            const string bcc = "bcc@testapp.de";
            const string subject = "Welcome to Akentas Mailer";
            const string templateName = "welcome";
            var placeholdersWithValues = new Dictionary<string, string> {{"link", "https://www.testapp.de/xyz8478"}};
            var sender = new MessageSender(messageBodyCreatorMock.Object, smtpClientMock.Object);

            sender.Send(from, to, bcc, subject, templateName, placeholdersWithValues);

            smtpClientMock.Verify(m => m.Send(It.IsAny<MailMessage>()), Times.Once);
        }
    }
}