using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Akentas.Mailer.Tests
{
    [TestClass]
    public class PlaceholdersReplacerTests
    {
        [TestMethod]
        public void PlaceholderReplacer_ReplacePlaceholders_Should_ReplaceOnePlaceholderWithCurlyBraces()
        {
            const string contentWithPlaceholder = "Some random text with {{placeholder}} in it.";
            const string expectedPlaceholderValue = "new value";
            var placeholderReplacer = new PlaceholdersReplacer();
            var contentWithReplacedPlaceholder = placeholderReplacer.ReplacePlaceholders(contentWithPlaceholder, new Dictionary<string, string>{{ "placeholder", expectedPlaceholderValue }});

            Assert.IsNotNull(contentWithReplacedPlaceholder);
            Assert.IsTrue(contentWithReplacedPlaceholder.IndexOf("{{placeholder}}", StringComparison.Ordinal) == -1, contentWithReplacedPlaceholder);
            Assert.IsTrue(contentWithReplacedPlaceholder.IndexOf($"text with {expectedPlaceholderValue} in it.", StringComparison.Ordinal) > -1, contentWithReplacedPlaceholder);
        }

        [TestMethod]
        public void PlaceholderReplacer_ReplacePlaceholders_Should_ReplaceOnePlaceholder()
        {
            const string contentWithPlaceholder = "Some random text with {{placeholder}} in it.";
            const string expectedPlaceholderValue = "new value";
            var placeholderReplacer = new PlaceholdersReplacer();
            var contentWithReplacedPlaceholder = placeholderReplacer.ReplacePlaceholders(contentWithPlaceholder, new Dictionary<string, string> { { "placeholder", expectedPlaceholderValue } });

            Assert.IsNotNull(contentWithReplacedPlaceholder);
            Assert.IsTrue(contentWithReplacedPlaceholder.IndexOf("{{placeholder}}", StringComparison.Ordinal) == -1);
            Assert.IsTrue(contentWithReplacedPlaceholder.IndexOf(expectedPlaceholderValue, StringComparison.Ordinal) > -1);
        }

        [TestMethod]
        public void PlaceholderReplacer_ReplacePlaceholders_Should_ReplaceMultiplePlaceholders()
        {
            const string contentWithPlaceholder = "Another random text with placeholders. My name is {{firstname}} {{lastname}} and I am a web developer.";
            const string expectedFirstnameValue = "Miro";
            const string expectedLastnameValue = "Grenda";

            var placeholdersWithValues = new Dictionary<string, string>
            {
                {"firstname", expectedFirstnameValue},
                {"lastname", expectedLastnameValue}
            };

            var placeholderReplacer = new PlaceholdersReplacer();
            var contentWithReplacedPlaceholder = placeholderReplacer.ReplacePlaceholders(contentWithPlaceholder, placeholdersWithValues);

            Assert.IsNotNull(contentWithReplacedPlaceholder);
            Assert.IsTrue(contentWithReplacedPlaceholder.IndexOf("{{firstname}}", StringComparison.Ordinal) == -1);
            Assert.IsTrue(contentWithReplacedPlaceholder.IndexOf("{{lastname}}", StringComparison.Ordinal) == -1);
            Assert.IsTrue(contentWithReplacedPlaceholder.IndexOf(expectedFirstnameValue, StringComparison.Ordinal) > -1);
            Assert.IsTrue(contentWithReplacedPlaceholder.IndexOf(expectedLastnameValue, StringComparison.Ordinal) > -1);
        }
    }
}
