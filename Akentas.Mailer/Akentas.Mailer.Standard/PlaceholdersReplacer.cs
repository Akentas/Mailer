using System.Collections.Generic;
using System.Text;

namespace Akentas.Mailer
{
    public class PlaceholdersReplacer : IPlaceholdersReplacer
    {
        public string ReplacePlaceholders(string content, Dictionary<string, string> placeholdersWithValues)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(content);

            foreach (var placeholderWithValue in placeholdersWithValues)
            {
                stringBuilder.Replace("{{" + placeholderWithValue.Key + "}}", placeholderWithValue.Value);
            }

            return stringBuilder.ToString();
        }
    }
}