using System;
using System.Collections.Generic;
using System.Text;

namespace Akentas.Mailer
{
    public class MessageBodyCreator : IMessageBodyCreator
    {
        private readonly IMessageTemplateReader _messageFileReader;
        private readonly IMessageSignatureReader _signatureFileReader;
        private readonly IPlaceholdersReplacer _placeholdersReplacer;

        public MessageBodyCreator(IMessageTemplateReader messageTemplateReader, IMessageSignatureReader messageSignatureReader) : this(messageTemplateReader, messageSignatureReader, null)
        {
        }

        public MessageBodyCreator(IMessageTemplateReader messageTemplateReader, IMessageSignatureReader messageSignatureReader, IPlaceholdersReplacer placeholdersReplacer)
        {
            _messageFileReader = messageTemplateReader;
            _signatureFileReader = messageSignatureReader;
            _placeholdersReplacer = placeholdersReplacer;
        }

        public string Create(string templateName)
        {
            return Create(templateName, null);
        }

        public string Create(string templateName, Dictionary<string, string> placeholdersWithValues)
        {
            var content = new StringBuilder();
            content.Append(_messageFileReader.Read(templateName));
            content.Append(_signatureFileReader.Read());

            var template = content.ToString();
            
            if (placeholdersWithValues != null)
            {
                if (_placeholdersReplacer == null)
                {
                    throw new Exception("PlaceholdersReplacer was not provided");
                }

                template = _placeholdersReplacer.ReplacePlaceholders(template, placeholdersWithValues);
            }

            return template;
        }
    }
}