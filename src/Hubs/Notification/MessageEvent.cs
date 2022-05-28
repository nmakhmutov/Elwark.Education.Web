namespace Education.Web.Hubs.Notification;

internal sealed record MessageEvent(string Content, string Subject, DateTime CreatedAt);
