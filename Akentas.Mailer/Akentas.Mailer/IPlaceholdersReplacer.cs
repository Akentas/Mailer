using System.Collections.Generic;

namespace Akentas.Mailer
{
    public interface IPlaceholdersReplacer
    {
        string ReplacePlaceholders(string someRandomTextWithPlaceholderInIt, Dictionary<string, string> placeholdersWithValues);
    }
}