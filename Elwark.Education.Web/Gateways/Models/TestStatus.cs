namespace Elwark.Education.Web.Gateways.Models
{
    public enum TestStatus
    {
        Allowed = 0,
        CreatedMaximumCurrentTests = 1,
        CreatedMaximumTests = 2,
        ReachedMaximumAnswerAttempts = 3,
        ArticlesNotCompleted = 4
    }
}