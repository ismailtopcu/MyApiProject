using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MimeKit;

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
            MailboxAddress mailboxAddress = new MailboxAddress("HotelierAdmin", "ismailtopcu92@gmail.com");
            mimeMessage.From.Add(mailboxAddress);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", adminMailViewModel.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody= adminMailViewModel.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject=adminMailViewModel.Subject;

            ISmtpClient client= new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("mail", "password key");
            client.Send(mimeMessage);
            client.Disconnect(true);
            return View();
        }
    }
}
