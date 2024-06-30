using Microsoft.AspNetCore.Components;

namespace Education.Client.Features.History.Clients.Article.Model;

public sealed record FactionModel(
    MarkupString? Belligerents,
    MarkupString? Commanders,
    MarkupString? Strength,
    MarkupString? Losses
);
