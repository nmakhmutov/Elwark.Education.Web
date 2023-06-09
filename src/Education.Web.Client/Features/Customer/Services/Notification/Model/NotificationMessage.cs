using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Education.Web.Client.Features.History;

namespace Education.Web.Client.Features.Customer.Services.Notification.Model;

public record NotificationMessage
{
    public NotificationMessage(
        string subject,
        string module,
        string title,
        string? message,
        Dictionary<string, string> payload,
        DateTime createdAt
    )
    {
        Subject = subject;
        Module = module;
        Title = title;
        Message = message;
        Payload = payload;
        CreatedAt = createdAt;
        Href = (subject, module) switch
        {
            ("History", "Inventory") => HistoryUrl.User.MyBackpack,
            ("History", "Achievement") => $"{HistoryUrl.User.MyAchievements}#{GetPayloadValue("id")}",
            ("History", "Profile") => HistoryUrl.User.MyProfile,
            _ => null
        };
    }

    public string Subject { get; }

    public string Module { get; }

    public string Title { get; }

    public string? Message { get; }

    public string? Href { get; }

    public Dictionary<string, string> Payload { get; }

    public DateTime CreatedAt { get; }

    private string? GetPayloadValue(string key)
    {
        ref var value = ref CollectionsMarshal.GetValueRefOrNullRef(Payload, key);
        return Unsafe.IsNullRef(ref value) ? null : value;
    }
}
