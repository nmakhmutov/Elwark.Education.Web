namespace Education.Web.Client.Services.Model;

public interface IInternalMoney
{
    public int Amount { get; }
}

public sealed record Experience(int Amount) : IInternalMoney;

public sealed record Silver(int Amount) : IInternalMoney;
