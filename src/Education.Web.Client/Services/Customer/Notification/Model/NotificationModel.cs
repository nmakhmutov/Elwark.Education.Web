namespace Education.Web.Client.Services.Customer.Notification.Model;

public sealed record NotificationModel(string Id, string Subject, string Title, string? Message, DateTime CreatedAt);
