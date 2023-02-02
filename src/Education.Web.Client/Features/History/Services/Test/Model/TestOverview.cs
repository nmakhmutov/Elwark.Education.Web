namespace Education.Web.Client.Features.History.Services.Test.Model;

public abstract record TestOverview(string Id, uint Completed, uint Questions, DateTime ExpiredAt)
{
    public sealed record EasyTestModel(string Id, uint Completed, uint Questions, DateTime ExpiredAt)
        : TestOverview(Id, Completed, Questions, ExpiredAt);

    public sealed record HardTestModel(string Id, uint Completed, uint Questions, DateTime ExpiredAt)
        : TestOverview(Id, Completed, Questions, ExpiredAt);

    public sealed record MixedTestModel(string Id, uint Completed, uint Questions, DateTime ExpiredAt)
        : TestOverview(Id, Completed, Questions, ExpiredAt);
}
