namespace Education.Client.Gateways.Store
{
    public sealed record Money(decimal Amount, Currency Currency)
    {
        public string Symbol =>
            Currency switch
            {
                Currency.Usd => "$",
                Currency.Eur => "€",
                Currency.Rub => "₽",
                _ => Currency.ToString()
            };
    }

    public enum Currency
    {
        Usd = 0,
        Eur = 1,
        Rub = 2
    }
}
