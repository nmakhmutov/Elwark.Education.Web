using Education.Web.Gateways.Models.Rule;

namespace Education.Web.Gateways.History.EventGuesser.Model;

public sealed record TestBuilderModel(
    TestRuleModel Rule,
    bool IsExistCurrent
);
