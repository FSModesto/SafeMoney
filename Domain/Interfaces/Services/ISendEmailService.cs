namespace Domain.Interfaces.Services
{
    public interface ISendEmailService
    {
        Task<bool> SendEmail(string recipient, string subject, string message);
    }
}
