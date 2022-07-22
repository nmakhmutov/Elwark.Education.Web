namespace Education.Web.Services.Notification.Model;

public sealed record NotificationModel(string Id, string Subject, string Title, string? Message, DateTime CreatedAt);
