namespace Akentas.Mailer
{
    public class MessageSignatureReader : IMessageSignatureReader
    {
        private readonly IMessageTemplateReader _messageTemplateReader;
        public const string SignatureName = "_signature";

        public MessageSignatureReader(IMessageTemplateReader messageTemplateReader)
        {
            _messageTemplateReader = messageTemplateReader;
        }

        public string Read()
        {
            return _messageTemplateReader.Read(SignatureName);
        }
    }
}