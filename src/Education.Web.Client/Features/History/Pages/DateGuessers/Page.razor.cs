using Blazored.LocalStorage;
using Education.Web.Client.Extensions;
using Education.Web.Client.Features.History.Services;
using Education.Web.Client.Features.History.Services.DateGuesser;
using Education.Web.Client.Features.History.Services.DateGuesser.Model;
using Education.Web.Client.Features.History.Services.DateGuesser.Request;
using Education.Web.Client.Http;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Web.Client.Features.History.Pages.DateGuessers;

public sealed partial class Page
{
    private bool _isLoading;
    private ApiResult<DateGuesserBuilderModel> _result = ApiResult<DateGuesserBuilderModel>.Loading();
    private Settings _settings = new(EpochType.None, null);

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private IHistoryDateGuesserService DateGuesserService { get; init; } = default!;

    [Inject]
    private ISnackbar Snackbar { get; init; } = default!;

    [Inject]
    private NavigationManager Navigation { get; init; } = default!;

    [Inject]
    private ILocalStorageService Storage { get; init; } = default!;

    private List<BreadcrumbItem> Breadcrumbs =>
    [
        new BreadcrumbItem(L["History_Title"], HistoryUrl.Root),
        new BreadcrumbItem(L["History_DateGuessers_Title"], null, true)
    ];

    protected override async Task OnInitializedAsync()
    {
        _settings = await Storage.GetItemAsync<Settings>(HistoryLocalStorageKey.DateGuesserSettings) ?? _settings;
        _result = await DateGuesserService.GetAsync();

        await _result.MatchAsync(
            model => model.Tests.Any(x => x.IsAllowed && x.Type == _settings.Type)
                ? Task.CompletedTask
                : OnSizeChanged(model.Tests.FirstOrDefault(x => x.IsAllowed)?.Type),
            error =>
            {
                if (error.IsDateGuesserAlreadyCreated(out var id))
                    Navigation.NavigateTo(HistoryUrl.DateGuesser.Test(id));
            }
        );
    }

    private async Task CreateTestAsync()
    {
        if (!_settings.Type.HasValue)
            return;

        _isLoading = true;

        var request = new CreateRequest(_settings.Type.Value, _settings.Epoch);
        (await DateGuesserService.CreateAsync(request))
            .Match(
                x => Navigation.NavigateTo(HistoryUrl.DateGuesser.Test(x.Id)),
                e => Snackbar.Add(e.Detail, Severity.Error)
            );

        _isLoading = false;
    }

    private async Task OnEpochChanged(EpochType epoch)
    {
        _settings = _settings with { Epoch = epoch };
        await Storage.SetItemAsync(HistoryLocalStorageKey.DateGuesserSettings, _settings);
    }

    private async Task OnSizeChanged(DateGuesserType? type)
    {
        _settings = _settings with { Type = type };
        await Storage.SetItemAsync(HistoryLocalStorageKey.DateGuesserSettings, _settings);
    }

    private sealed record Settings(EpochType Epoch, DateGuesserType? Type);
}
