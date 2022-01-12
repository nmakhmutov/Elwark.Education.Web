namespace Education.Client.Gateways.Models.User;

public sealed record UserProfile(Level Level, Wallet Wallet, Transaction[] Transactions);

public sealed record Level(uint Value, ulong Experience, ulong NextLevelExperience);

public sealed record Wallet(long Experience, long Silver);

public sealed record Transaction(TransactionType Type, DateTime CreatedAt, IGameCurrency[] Currencies, string? Comment);

public enum TransactionType
{
    LevelUp = 0,
    DailyReward = 1,
    EasyTest = 2,
    HardTest = 3,
    MixedTest = 4,
    EventGuesser = 5,
    Achievement = 6
}
