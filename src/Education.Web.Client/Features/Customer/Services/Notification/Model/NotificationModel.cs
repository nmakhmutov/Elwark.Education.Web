namespace Education.Web.Client.Features.Customer.Services.Notification.Model;

public sealed record NotificationModel(string Id, string Subject, string Title, string? Message, DateTime CreatedAt);
