using Education.Client.Gateways.Models.Rule;

namespace Education.Client.Gateways.History.EventGuesser.Model;

public sealed record TestBuilderModel(
    TestRuleModel Rule,
    bool IsExistCurrent
);
