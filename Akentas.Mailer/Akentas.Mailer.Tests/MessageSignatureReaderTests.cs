using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Akentas.Mailer.Tests
{
    [TestClass]
    public class MessageSignatureReaderTests
    {
        [TestMethod]
        public void MessageSignatureReader_ReadEmailTemplate_Should_ReadTheWelcomeEmailTemplate()
        {
            var config = new Config();
            var messageTemplateReader = new MessageTemplateReader(config.MessagesTemplatesRootDirectory);
            var messageSignatureReader = new MessageSignatureReader(messageTemplateReader);
            var signature = messageSignatureReader.Read();

            Assert.IsNotNull(signature);
            Assert.IsTrue(signature.IndexOf("[SIGNATURE]", StringComparison.Ordinal) > -1);
        }
    }
}