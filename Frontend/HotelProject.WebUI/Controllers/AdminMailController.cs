using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminMailViewModel adminMailViewModel)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddress = new MailboxAddress("MimozaOtelAdmin","dev.burakfiliz@gmail.com"); //Kimden
            mimeMessage.From.Add(mailboxAddress);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", adminMailViewModel.ReceiverMail);  //Kime
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = adminMailViewModel.Body;   //İçerik
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = adminMailViewModel.Subject;
            SmtpClient client = new SmtpClient();            //using Mailkiti kullandık
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("dev.burakfiliz@gmail.com", "cbtnirechrdfgxgl");
            client.Send(mimeMessage);
            client.Disconnect(true);
            return View();
        }
    }
}
