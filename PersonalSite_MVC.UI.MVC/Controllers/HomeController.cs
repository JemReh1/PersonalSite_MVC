using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using PersonalSite_MVC.UI.MVC.Models;

namespace PersonalSite_MVC.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public JsonResult ContactAjax(ContactViewModel cvm)
        {
            string body = $"{cvm.Name} has sent you the following message: <br/>" +
                $"{cvm.Message} <strong>from the email address: </strong> {cvm.Email}";//body of the message sent

            MailMessage m = new MailMessage("JeremySidener@jeremysidener.com", "jeremyrsidener@gmail.com",
                cvm.Subject, body);//subject of the email

            m.IsBodyHtml = true;//allows html in email

            m.Priority = MailPriority.High;//made it high priority

            m.ReplyToList.Add(cvm.Email);//reply to recipient of form 

            SmtpClient client = new SmtpClient("mail.jeremysidener.com");//configure your email

            client.Credentials = new NetworkCredential("admin@jeremysidener.com", "pass4ASP*");

            try
            {
                client.Send(m);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.StackTrace;
            }
            return Json(cvm);
        }
    }
}