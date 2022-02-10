using Education.Client.Gateways.Models;

namespace Education.Client.Gateways.Customer;

public sealed record Notification(string Message, SubjectType Subject, DateTime CreatedAt);
