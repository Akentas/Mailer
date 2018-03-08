using System.Configuration;

namespace Akentas.Mailer
{
    public class Config : IConfig
    {
        public string MessagesTemplatesRootDirectory => ConfigurationManager.AppSettings["AkentasMailer.MessagesTemplatesRootDirectory"];
    }
}
