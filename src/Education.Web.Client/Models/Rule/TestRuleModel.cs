using Microsoft.AspNetCore.Components;

namespace Education.Web.Client.Models.Rule;

public sealed record TestRuleModel(string Title, MarkupString Content);
