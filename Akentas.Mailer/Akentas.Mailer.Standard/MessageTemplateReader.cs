using System;
using System.IO;
using System.Text;

namespace Akentas.Mailer
{
    public class MessageTemplateReader : IMessageTemplateReader
    {
        private readonly string _messagesTemplatesRootPath;

        public MessageTemplateReader(string messagesTemplatesRootPath)
        {
            _messagesTemplatesRootPath = messagesTemplatesRootPath;
        }

        public string Read(string name)
        {
            var filepath = Path.Combine(_messagesTemplatesRootPath, $"{name}.txt");

            if (!File.Exists(filepath))
            {
                throw new Exception($"File '{filepath}' not found.");
            }

            string content;

            using (var sr = new StreamReader(filepath, Encoding.Default))
            {
                content = sr.ReadToEnd();
                sr.Close();
            }

            return content;
        }
    }
}