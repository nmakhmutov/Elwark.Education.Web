namespace Education.Web.Gateways.Customers.Model;

public sealed record NotificationModel(string Id, string Subject, string Title, string? Message, DateTime CreatedAt);
