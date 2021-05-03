namespace Elwark.Education.Web.Gateways.Models.User
{
    public sealed record Subscription(SubscriptionType Type, Purchase? Purchase);
    
    public enum SubscriptionType
    {
        Free = 0,
        Basic = 1,
        Advanced = 2
    }
}
