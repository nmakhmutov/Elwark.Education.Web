namespace Education.Web.Hubs.Notification;

public sealed record MessageModel(string Id, string Content, string Subject, DateTime CreatedAt);
