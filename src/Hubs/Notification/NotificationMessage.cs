namespace Education.Web.Hubs.Notification;

internal sealed record NotificationMessage(string Content, string Subject, DateTime CreatedAt);
