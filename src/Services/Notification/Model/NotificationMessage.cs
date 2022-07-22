namespace Education.Web.Services.Notification.Model;

public sealed record NotificationMessage(string Subject, string Title, string? Message, DateTime CreatedAt);
