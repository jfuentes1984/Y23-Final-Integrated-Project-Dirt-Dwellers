namespace Y23_DirtDwellers.Services;

public interface IMailService
{
    public Task SendMailAsync(string to, string subject, string body);
}