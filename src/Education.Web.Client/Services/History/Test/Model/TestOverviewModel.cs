namespace Education.Web.Client.Services.History.Test.Model;

public abstract record TestOverviewModel(string Id, uint Completed, uint Questions, DateTime ExpiredAt);

public sealed record EasyTestOverviewModel(string Id, uint Completed, uint Questions, DateTime ExpiredAt)
    : TestOverviewModel(Id, Completed, Questions, ExpiredAt);

public sealed record HardTestOverviewModel(string Id, uint Completed, uint Questions, DateTime ExpiredAt)
    : TestOverviewModel(Id, Completed, Questions, ExpiredAt);

public sealed record MixedTestOverviewModel(string Id, uint Completed, uint Questions, DateTime ExpiredAt)
    : TestOverviewModel(Id, Completed, Questions, ExpiredAt);
