using System.IO;

namespace Akentas.Mailer.Tests
{
    public class Config : IConfig
    {
        public string MessagesTemplatesRootDirectory => Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\WebApplicationToTestMailer\App_Data\Mailer-Templates"));
    }
}