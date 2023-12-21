namespace Education.Client.Features.Customer.Services.Notification.Model;

public sealed record NotificationModel(
    string Id,
    string Subject,
    string Module,
    string Title,
    string Message,
    IReadOnlyDictionary<string, string> Payload,
    DateTime CreatedAt
) : NotificationBase(Subject, Module, Title, Message, Payload, CreatedAt);
