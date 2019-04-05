using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace EOATicaret.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        /*[HttpGet]
        public ActionResult emailYolla(string receiver, string subject, string mes)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 25;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("eoaticaret@gmail.com", "123456789+K");

            using (var message = new MailMessage("eoaticaret@gmail.com", "fevzikazik@gmail.com"))
            {
                message.Subject = "deneme";
                message.Body = "osman mert";
                message.IsBodyHtml = false;
                smtp.Send(message);
            }

            return Json("başarılı");
        }*/

        [HttpPost]
        public ActionResult SendEmail(string receiver, string subject, string mes)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                    var message = new MailMessage();
                    message.To.Add(new MailAddress("fevzikazik@hotmail.com"));  // replace with valid value 
                    message.From = new MailAddress("fevzikazik@hotmail.com");  // replace with valid value
                    message.Subject = "Your email subject";
                    message.Body = string.Format(body, "fevzi", subject, mes);
                    message.IsBodyHtml = true;

                    using (var smtp = new SmtpClient())
                    {
                        var credential = new NetworkCredential
                        {
                            UserName = "fevzikazik@hotmail.com",  // replace with valid value
                            Password = "yamanali41"  // replace with valid value
                        };
                        smtp.Credentials = credential;
                        smtp.Host = "smtp-mail.outlook.com";
                        smtp.Port = 25;
                        smtp.EnableSsl = true;
                        smtp.SendMailAsync(message);
                    }
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return RedirectToAction("Index");
        }
    }
}