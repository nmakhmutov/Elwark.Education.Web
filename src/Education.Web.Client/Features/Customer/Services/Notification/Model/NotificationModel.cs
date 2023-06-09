namespace Education.Web.Client.Features.Customer.Services.Notification.Model;

public sealed record NotificationModel(
    string Id,
    string Subject,
    string Module,
    string Title,
    string? Message,
    Dictionary<string, string> Payload,
    DateTime CreatedAt
) : NotificationMessage(Subject, Module, Title, Message, Payload, CreatedAt);
