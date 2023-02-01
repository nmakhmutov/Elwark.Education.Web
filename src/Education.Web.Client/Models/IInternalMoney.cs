namespace Education.Web.Client.Models;

public interface IInternalMoney
{
    public uint Amount { get; }
}

public sealed record Experience(uint Amount) : IInternalMoney;

public sealed record Silver(uint Amount) : IInternalMoney;
