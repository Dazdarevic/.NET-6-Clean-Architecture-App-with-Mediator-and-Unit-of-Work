using Napredne_baze_podataka_API.Interfaces;
using System.Net;
using System.Net.Mail;

namespace Napredne_baze_podataka_API.Data.Repo
{
    public class EmailSenderRepository : IEmailSenderRepository
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SmtpClient("smtp.office365.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("belkisa.dazdarevic1@gmail.com", "kvazilend5")
            };

            return client.SendMailAsync(
                new MailMessage(from: "belkisa.dazdarevic1@gmail.com",
                                to: email,
                                subject,
                                message
                                ));
        }
    }
}
