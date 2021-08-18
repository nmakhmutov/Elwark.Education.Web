namespace Education.Client.Gateways.Customer
{
    public record Customer(long Id, string Name, string Language, Subject[] Subjects);
}
