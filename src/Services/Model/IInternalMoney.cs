namespace Education.Web.Services.Model;

public interface IInternalMoney
{
}

public sealed record Experience(int Amount) : IInternalMoney;

public sealed record Silver(int Amount) : IInternalMoney;
