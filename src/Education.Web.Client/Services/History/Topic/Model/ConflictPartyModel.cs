using Microsoft.AspNetCore.Components;

namespace Education.Web.Client.Services.History.Topic.Model;

public sealed record ConflictPartyModel(MarkupString Belligerents, MarkupString Commanders, MarkupString Strength, MarkupString Losses);
