using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using ecomAdminPanel.Models.Entity;

namespace ecomAdminPanel.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        

        public ActionResult Index()
        {
            if (Session["LoggedUser"] != null)
            {
                return View();
            }
            return RedirectToAction("Login");
        }

        [HttpGet]
        
        // GET: Login
        public ActionResult Login()
        {
            if (Session["LoggedUser"] == null)
                return View();
            else
                SendMail("mali@hotmail.com", "Admin Panele Giriş Yaptınız", "<strong>Dear Mali</strong><br><p>Girişiniz başarılıdır</p>");
                return RedirectToAction("Index");
        }
        public void SendMail(string toMailAddress, string subject, string body)
        {
            //Maili gönderecek olan hostu set etmek
            SmtpClient client = new SmtpClient("mail.microsoft.com");
            //SmtpClient'in göndereceği mail config etmek
            //MailMessage msg = new MailMessage("bill@microsoft.com", "paul@microsoft.com");
            MailAddress fromAddress = new MailAddress("mehmetali@hotmail.com", "Mehmet Ali Ekici");
            MailAddress toAddress = new MailAddress(toMailAddress);
            MailMessage msg = new MailMessage(fromAddress, toAddress);
            msg.Subject = subject;
            msg.IsBodyHtml = true;
            msg.Body = body;

            //Güvenlik Ayarlar 
            NetworkCredential credential = new NetworkCredential("mehmetali@hotmail.com", "123456");
            client.Credentials = credential;
            //Maili göndermek
            client.Send(msg);
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            ecomAdminPanelDBEntities db = new ecomAdminPanelDBEntities();
            var user = (from i in db.Adminİnfo
                        where i.Username.Equals(username) && i.Password.Equals(password)
                        select i).SingleOrDefault();    

            if (user == null)
                return RedirectToAction("Login");
            else
            {
                Session.Add("LoggedUser", user);
                return RedirectToAction("Index","Categories");
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }

    }
}