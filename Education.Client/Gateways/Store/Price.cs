namespace Education.Client.Gateways.Store
{
    public sealed record Price(decimal Amount, decimal Discount, decimal Total, Currency Currency)
    {
        public string Symbol => Currency.GetSymbol();
    }
    
    public enum Currency
    {
        Usd = 0,
        Eur = 1,
        Rub = 2
    }

    public static class CurrencyExtensions
    {
        public static string GetSymbol(this Currency currency) =>
            currency switch
            {
                Currency.Usd => "$",
                Currency.Eur => "€",
                Currency.Rub => "₽",
                _ => currency.ToString()
            };
    }
}
