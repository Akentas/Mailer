using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Akentas.Mailer.Tests
{
    [TestClass]
    public class MessageTemplateReaderTests
    {
        [TestMethod]
        public void MessageTemplateReader_ReadEmailTemplate_Should_ReadTheWelcomeEmailTemplate()
        {
            var config = new Config();
            const string templateName = "welcome";
            var messageTemplateReader = new MessageTemplateReader(config.MessagesTemplatesRootDirectory);
            var templateContent = messageTemplateReader.Read(templateName);

            Assert.IsNotNull(templateContent);
            Assert.IsTrue(templateContent.IndexOf("Welcome", StringComparison.Ordinal) > -1);
        }

        [TestMethod]
        public void MessageTemplateReader_ReadEmailTemplate_Should_ReadTheResetPasswordEmailTemplate()
        {
            var config = new Config();
            const string templateName = "reset-password";
            var messageTemplateReader = new MessageTemplateReader(config.MessagesTemplatesRootDirectory);
            var templateContent = messageTemplateReader.Read(templateName);

            Assert.IsNotNull(templateContent);
            Assert.IsTrue(templateContent.IndexOf("reset your password", StringComparison.Ordinal) > -1);
        }
    }
}
