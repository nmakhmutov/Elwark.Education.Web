namespace Education.Web.Hubs.Notification;

internal sealed record NotificationMessage(string Subject, string Title, string? Message, DateTime CreatedAt);
