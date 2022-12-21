namespace Education.Web.Client.Services.Notification.Model;

public sealed record NotificationModel(string Id, string Subject, string Title, string? Message, DateTime CreatedAt);
