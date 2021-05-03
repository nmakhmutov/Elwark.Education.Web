namespace Elwark.Education.Web.Gateways.Models
{
    public enum TestStatus
    {
        NotAvailable = 0,
        Allowed = 1,
        CreatedMaximumCurrentTests = 2,
        CreatedMaximumTests = 3,
        ReachedMaximumAnswerAttempts = 4
    }
}
