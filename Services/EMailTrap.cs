using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;


namespace Y23_DirtDwellers.Services;
public class EMailTrap : IMailService
{
    public async Task SendMailAsync(string to, string subject, string body)
    {
        BodyBuilder bb = new();
        bb.HtmlBody = body;
        MailboxAddress fromAddress = new(Configuration["Email:Name"], Configuration["Email:Address"]);
        var toAddress = MailboxAddress.Parse(to);
        await SendMailAsync(fromAddress, toAddress, subject, bb);
    }

    public async Task SendMailAsync(MailboxAddress from, MailboxAddress to, string subject, BodyBuilder body)
    {
        var msg = new MimeMessage { Subject = subject };
        msg.To.Add(to);
        msg.From.Add(from);
        msg.Body = body.ToMessageBody();

        using SmtpClient client = new();
        await client.ConnectAsync(Configuration["smtp.mailtrap.io"], int.Parse(Configuration["587"]), false);
        await client.AuthenticateAsync(Configuration["9df9883b2fc1c8"], Configuration["8ea3523a36f91e"]);
        await client.SendAsync(msg);
        await client.DisconnectAsync(true);

    }

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        await SendMailAsync(email, subject, htmlMessage);
    }

    public IConfiguration Configuration { get; }

    public EMailTrap(IConfiguration conf)
    {
        Configuration = conf;
    }
}