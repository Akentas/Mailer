using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Akentas.Mailer;

namespace WebApplicationToTestMailer.Controllers
{
    public class TestTemplateResetPasswordController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string sender, string to, string bcc, string subject)
        {
            var messagesTemplatesRootPath = Server.MapPath(ConfigurationManager.AppSettings["AkentasMailer.MessagesTemplatesRootDirectory"]);
            var placeholdersWithValues = new Dictionary<string, string> { { "link", "https://www.testapp.de/xyz8478" } };
            var emailSender = new EmailSender(messagesTemplatesRootPath);
            emailSender.SendEmail(sender, to, bcc, subject, "reset-password", placeholdersWithValues);

            ViewBag.Message = $"Reset-Password message has been sent to {to}";

            return View();
        }
    }
}