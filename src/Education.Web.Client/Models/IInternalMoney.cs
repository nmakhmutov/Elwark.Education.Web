namespace Education.Web.Client.Models;

public interface IInternalMoney
{
    public string Currency { get; }
    
    public uint Amount { get; }
}

public sealed record Experience(uint Amount) : IInternalMoney
{
    public string Currency =>
        nameof(Experience);
}

public sealed record Silver(uint Amount) : IInternalMoney
{
    public string Currency =>
        nameof(Silver);
}
