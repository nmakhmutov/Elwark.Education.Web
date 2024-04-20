using Education.Client.Features.History;
using Education.Client.Models;

namespace Education.Client.Features.Customer.Services.Notification.Model;

public abstract record NotificationBase
{
    private readonly List<InternalMoneyModel> _money;
    private readonly IReadOnlyDictionary<string, string> _payload;

    protected NotificationBase(
        string subject,
        string module,
        string title,
        string message,
        IReadOnlyDictionary<string, string> payload,
        DateTime createdAt
    )
    {
        Subject = subject;
        Module = module;
        Title = title;
        Message = message;
        CreatedAt = createdAt;

        _payload = payload;
        _money = [];

        DisassemblePayload();
    }

    public string Subject { get; }

    public string Module { get; }

    public string Title { get; }

    public string Message { get; }

    public DateTime CreatedAt { get; }

    public string? Href { get; private set; }

    public bool HasMoney =>
        _money.Count > 0;

    public IReadOnlyCollection<InternalMoneyModel> Money =>
        _money.AsReadOnly();

    private void DisassemblePayload()
    {
        foreach (var (key, value) in _payload)
        {
            if (InternalCurrencyExtensions.ParseValueOrDefault(key) is { } currency)
                _money.Add(new InternalMoneyModel(currency, uint.Parse(value)));
        }

        Href = (Subject, Module) switch
        {
            ("History", "Inventory") =>
                HistoryUrl.User.MyBackpack,

            ("History", "Achievement") =>
                HistoryUrl.User.MyAchievements,

            ("History", "Profile") =>
                HistoryUrl.User.MyDashboard,

            ("History", "MonthlyLeaderboard") =>
                HistoryUrl.Leaderboard.Monthly(DateOnly.ParseExact(_payload["month"], "O")),

            ("History", "Assignment") =>
                HistoryUrl.User.MyAssignments(_payload["type"]),

            _ => null
        };
    }
}
