namespace InvenTracker.Application.Iterfaces;

public interface IEmailService
{
    Task SendLowStockAlertAsync(string toEmail, string itemName, int currentQuantity, int minQuantity);
}