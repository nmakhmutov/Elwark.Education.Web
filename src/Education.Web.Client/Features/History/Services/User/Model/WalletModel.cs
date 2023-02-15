namespace Education.Web.Client.Features.History.Services.User.Model;

public sealed record WalletModel(long Silver, WalletModel.BackpackModel Backpack)
{
    public sealed record BackpackModel(uint Capacity, uint Fullness, uint Emptiness);
}
