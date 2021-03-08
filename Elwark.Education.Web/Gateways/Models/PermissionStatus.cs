namespace Elwark.Education.Web.Gateways.Models
{
    public enum PermissionStatus
    {
        Allowed = 0,
        CreatedMaximumCurrentTests = 1,
        CreatedMaximumTests = 2,
        ReachedMaximumAnswerAttempts = 3,
        PremiumSubscriptionRequired = 4
    }
}
