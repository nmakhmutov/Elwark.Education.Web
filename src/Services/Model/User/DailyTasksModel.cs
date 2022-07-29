namespace Education.Web.Services.Model.User;

public sealed record DailyTasksModel(
    DailyTasksModel.DailyTasksStatus Status,
    DateTime? ExpiresAt,
    DailyTasksModel.ItemModel[] Items,
    IInternalMoney[] Rewards
)
{
    public sealed record ItemModel(string Title, uint Score, uint Threshold, bool IsCompleted);

    public enum DailyTasksStatus
    {
        InProgress = 0,
        Expired = 1,
        Completed = 2,
        Collected = 3,
    }
}
