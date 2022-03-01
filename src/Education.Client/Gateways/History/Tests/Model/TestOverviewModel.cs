namespace Education.Client.Gateways.History.Tests.Model;

public abstract record TestOverviewModel(string Id, uint CompletedQuestions, uint TotalQuestions, DateTime ExpiredAt);

public sealed record EasyTestOverviewModel(string Id, uint CompletedQuestions, uint TotalQuestions, DateTime ExpiredAt)
    : TestOverviewModel(Id, CompletedQuestions, TotalQuestions, ExpiredAt);

public sealed record HardTestOverviewModel(string Id, uint CompletedQuestions, uint TotalQuestions, DateTime ExpiredAt)
    : TestOverviewModel(Id, CompletedQuestions, TotalQuestions, ExpiredAt);

public sealed record MixedTestOverviewModel(string Id, uint CompletedQuestions, uint TotalQuestions, DateTime ExpiredAt)
    : TestOverviewModel(Id, CompletedQuestions, TotalQuestions, ExpiredAt);
