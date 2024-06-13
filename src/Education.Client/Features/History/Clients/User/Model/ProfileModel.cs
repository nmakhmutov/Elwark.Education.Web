namespace Education.Client.Features.History.Clients.User.Model;

public sealed record ProfileModel(
    UserLevelModel Level,
    BackpackOverviewModel Backpack,
    Dictionary<InternalCurrency, long> Wallet
)
{
    public static readonly ProfileModel Empty =
        new(new UserLevelModel(1, 0, 0), new BackpackOverviewModel(0, 0, 0), []);
}
