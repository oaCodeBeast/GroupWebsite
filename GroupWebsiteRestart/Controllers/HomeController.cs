using GroupWebsiteRestart.Models;
using System.Net.Mail;
using System.Web.Mvc;

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string name, string email, string subject, string message)
        {
            if (name != null && email != null && subject != null && message != null)
            {
                ContactViewModel c1 = new ContactViewModel();
                c1.Name = name;
                c1.Email = email;
                c1.Subject = subject;
                c1.Message = message;

                string body = string.Format("Name: {0}<br/>Email: {1}<br/>{2}",
                   c1.Name,
                   c1.Email,
                   c1.Message);

                MailMessage msg = new MailMessage("centriqRelay@gmail.com",
                    "oabdulaziz32@gmail.com", "Group website mail " + c1.Subject, body);
                msg.CC.Add("james.mcdaniel@themcdanielcode.com");
                msg.CC.Add("bradtknowles@gmail.com");
                msg.CC.Add("sethjpearson@gmail.com");
                msg.CC.Add("livelifehd@gmail.com");
                msg.CC.Add("jb198720131@gmail.com");
                msg.IsBodyHtml = true;
                msg.Priority = MailPriority.High;

                using (SmtpClient client = new SmtpClient())
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential("centriqRelay@gmail.com", "c3ntriQc3ntriQ");
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //send messege
                    client.Send(msg);
                }
                return RedirectToAction("Confirmation", c1);

            }
            else
            {
                ViewBag.Message = "Unfortunatly something went awry";
                return View();
            }


        }
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(string name, string email, string subject, string message)
        {
            if (name != null && email != null && subject != null && message != null)
            {
                ContactViewModel c1 = new ContactViewModel();
                c1.Name = name;
                c1.Email = email;
                c1.Subject = subject;
                c1.Message = message;

                string body = string.Format("Name: {0}<br/>Email: {1}<br/>{2}",
                   c1.Name,
                   c1.Email,
                   c1.Message);

                MailMessage msg = new MailMessage("centriqRelay@gmail.com",
                    "oabdulaziz32@gmail.com", "Group website mail " + c1.Subject, body);
                msg.CC.Add("james.mcdaniel@themcdanielcode.com");
                msg.CC.Add("bradtknowles@gmail.com");
                msg.CC.Add("sethjpearson@gmail.com");
                msg.CC.Add("livelifehd@gmail.com");
                msg.CC.Add("jb198720131@gmail.com");
                msg.IsBodyHtml = true;
                msg.Priority = MailPriority.High;

                using (SmtpClient client = new SmtpClient())
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential("centriqRelay@gmail.com", "c3ntriQc3ntriQ");
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //send messege
                    client.Send(msg);
                }
                return RedirectToAction("Confirmation", c1);

            }
            else
            {
                ViewBag.Message = "Unfortunatly something went awry";
                return View();
            }


        }
        public ActionResult Confirmation(ContactViewModel c1)
        {
            ViewBag.Message = string.Format("Thanks, We'll get back to you soon {0}", c1.Name);
            return View();
        }
    }
}
