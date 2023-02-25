namespace Education.Web.Client.Features.History.Services.User.Model;

public sealed record WalletModel(IDictionary<string, long> Monies, WalletModel.BackpackModel Backpack)
{
    public sealed record BackpackModel(uint Capacity, uint Fullness, uint Emptiness);
}