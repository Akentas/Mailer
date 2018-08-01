using System.Collections.Generic;

namespace Akentas.Mailer
{
    public interface IMessageBodyCreator
    {
        string Create(string templateName);
        string Create(string templateName, Dictionary<string, string> placeholdersWithValues);
    }
}