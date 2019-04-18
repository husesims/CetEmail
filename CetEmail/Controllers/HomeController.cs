using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CetEmail.Models;
using System.Net.Mail;
using System.Net;

namespace CetEmail.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SendMail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMail(MailModel input)
        {
            if(ModelState.IsValid)
            {
                using(var mail=new MailMessage())
                {
                    mail.From = new MailAddress("cet322@gmail.com", "!!CET 322!!");
                    mail.To.Add(input.To);
                    mail.CC.Add("huseyinsimsek@gmail.com");
                    mail.Subject = input.Subject;
                    mail.Body = input.Body;
                    mail.IsBodyHtml = false;
                    using (var smtpClient=new SmtpClient())
                    {
                        smtpClient.Host = "smtp.gmail.com";
                        smtpClient.Port = 587;
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = new NetworkCredential("cet322@gmail.com", "123Qaz*=");
                        smtpClient.EnableSsl = true;
                        smtpClient.Send(mail);
                    }

                }
            }
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
