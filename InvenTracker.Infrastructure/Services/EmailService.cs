using System.Net;
using System.Net.Mail;
using InvenTracker.Application.Iterfaces;
using InvenTracker.Application.Settings;
using Microsoft.Extensions.Options;

namespace InvenTracker.Infrastructure.Services;

public class EmailService : IEmailService
{
    private readonly EmailSettings _settings;

    public EmailService(IOptions<EmailSettings> options)
    {
        _settings = options.Value;
    }

    public async Task SendLowStockAlertAsync(string toEmail, string itemName, int currentQuantity, int minQuantity)
    {
        using var client = new SmtpClient(_settings.Host, _settings.Port)
        {
            Credentials = new NetworkCredential(_settings.Username, _settings.Password),
            EnableSsl = true
        };

        var subject = $"Niski stan magazynowy: {itemName}";
        var body = $"Przedmiot '{itemName}' osiągnął niski stan.\n\n" +
                   $"Aktualny stan: {currentQuantity}\n" +
                   $"Minimum: {minQuantity}";

        await client.SendMailAsync(_settings.From, toEmail, subject, body);
    }
}