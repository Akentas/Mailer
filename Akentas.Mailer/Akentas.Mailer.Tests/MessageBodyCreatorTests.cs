using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Akentas.Mailer.Tests
{
    [TestClass]
    public class MessageBodyCreatorTests
    {
        [TestMethod]
        public void MessageBodyCreator_Create_Should_CreateWelcomeMessageBody()
        {
            var config = new Config();
            const string templateName = "welcome";
            var messageTemplateReader = new MessageTemplateReader(config.MessagesTemplatesRootDirectory);
            var messageSignatureReader = new MessageSignatureReader(messageTemplateReader);
            var messageBodyCreator = new MessageBodyCreator(messageTemplateReader, messageSignatureReader);
            var messageBody = messageBodyCreator.Create(templateName);

            Assert.IsNotNull(messageBody);
            Assert.IsTrue(messageBody.IndexOf("Welcome", StringComparison.Ordinal) > -1);
        }

        [TestMethod]
        public void MessageBodyCreator_Create_Should_CreateWelcomeMessageWithReplacedLink()
        {
            var config = new Config();
            const string templateName = "welcome";
            const string placeholderValue = "https://thenewlink.com";
            var messageTemplateReader = new MessageTemplateReader(config.MessagesTemplatesRootDirectory);
            var messageSignatureReader = new MessageSignatureReader(messageTemplateReader);
            var placeholdersReplacer = new PlaceholdersReplacer();
            var messageBodyCreator = new MessageBodyCreator(messageTemplateReader, messageSignatureReader, placeholdersReplacer);
            var placeholdersWithValues = new Dictionary<string, string> { { "link", placeholderValue } };
            var messageBody = messageBodyCreator.Create(templateName, placeholdersWithValues);

            Assert.IsNotNull(messageBody);
            Assert.IsTrue(messageBody.IndexOf("Welcome", StringComparison.Ordinal) > -1);
            Assert.IsTrue(messageBody.IndexOf(placeholderValue, StringComparison.Ordinal) > -1);
        }

        [TestMethod]
        public void MessageBodyCreator_Create_Should_CreateResetPasswordMessage()
        {
            var config = new Config();
            const string templateName = "reset-password";
            const string placeholderValue = "https://thenewlink.com";
            var messageTemplateReader = new MessageTemplateReader(config.MessagesTemplatesRootDirectory);
            var messageSignatureReader = new MessageSignatureReader(messageTemplateReader);
            var placeholdersReplacer = new PlaceholdersReplacer();
            var messageBodyCreator = new MessageBodyCreator(messageTemplateReader, messageSignatureReader, placeholdersReplacer);
            var placeholdersWithValues = new Dictionary<string, string> { { "link", placeholderValue } };
            var messageBody = messageBodyCreator.Create(templateName, placeholdersWithValues);

            Assert.IsNotNull(messageBody);
            Assert.IsTrue(messageBody.IndexOf("reset your password", StringComparison.Ordinal) > -1);
        }

        [TestMethod]
        public void MessageBodyCreator_Create_Should_CreateResetPasswordMessageWithReplacedLink()
        {
            var config = new Config();
            const string templateName = "reset-password";
            const string placeholderValue = "https://thenewlink.com";
            var messageTemplateReader = new MessageTemplateReader(config.MessagesTemplatesRootDirectory);
            var messageSignatureReader = new MessageSignatureReader(messageTemplateReader);
            var placeholdersReplacer = new PlaceholdersReplacer();
            var messageBodyCreator = new MessageBodyCreator(messageTemplateReader, messageSignatureReader, placeholdersReplacer);
            var placeholdersWithValues = new Dictionary<string, string> { { "link", placeholderValue } };
            var messageBody = messageBodyCreator.Create(templateName, placeholdersWithValues);

            Assert.IsNotNull(messageBody);
            Assert.IsTrue(messageBody.IndexOf("reset your password", StringComparison.Ordinal) > -1);
            Assert.IsTrue(messageBody.IndexOf(placeholderValue, StringComparison.Ordinal) > -1);
        }
    }
}
