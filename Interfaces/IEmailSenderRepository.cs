namespace Napredne_baze_podataka_API.Interfaces
{
    public interface IEmailSenderRepository
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
