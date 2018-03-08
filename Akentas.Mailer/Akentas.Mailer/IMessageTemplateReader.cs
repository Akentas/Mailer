namespace Akentas.Mailer
{
    public interface IMessageTemplateReader
    {
        string Read(string templateName);
    }
}