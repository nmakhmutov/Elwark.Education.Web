namespace Education.Web.Client.Services.Customer.Notification.Model;

public sealed record NotificationMessage(string Subject, string Title, string? Message, DateTime CreatedAt);
