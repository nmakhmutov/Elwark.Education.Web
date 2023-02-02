using Microsoft.AspNetCore.Components;

namespace Education.Web.Client.Features.History.Services.Article.Model;

public sealed record ConflictPartyModel(
    MarkupString Belligerents,
    MarkupString Commanders,
    MarkupString Strength,
    MarkupString Losses
);
