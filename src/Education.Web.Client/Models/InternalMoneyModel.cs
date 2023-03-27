namespace Education.Web.Client.Models;

public enum InternalCurrency
{
    Experience,
    Silver
}

public sealed record InternalMoneyModel(InternalCurrency Currency, uint Amount);
