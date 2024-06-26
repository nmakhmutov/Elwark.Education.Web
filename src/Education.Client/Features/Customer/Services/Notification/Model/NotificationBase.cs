using Education.Client.Features.History;
using Education.Client.Features.History.Clients;

namespace Education.Client.Features.Customer.Services.Notification.Model;

public abstract record NotificationBase
{
    private readonly List<GameMoneyModel> _money;

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
        _money = [];

        foreach (var (key, value) in payload)
        {
            if (GameCurrencyExtensions.ParseValueOrDefault(key) is { } currency)
                _money.Add(new GameMoneyModel(currency, uint.Parse(value)));
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
                HistoryUrl.Leaderboard.Monthly(payload["month"]),

            ("History", "Assignment") =>
                HistoryUrl.User.MyAssignments(payload["type"]),

            _ => EduUrl.Root
        };
    }

    public string Subject { get; }

    public string Module { get; }

    public string Title { get; }

    public string Message { get; }

    public DateTime CreatedAt { get; }

    public string Href { get; private set; }

    public bool HasMoney =>
        _money.Count > 0;

    public IReadOnlyCollection<GameMoneyModel> Money =>
        _money.AsReadOnly();
}
