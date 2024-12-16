using Blazored.LocalStorage;
using Education.Client.Clients;
using Education.Client.Extensions;
using Education.Client.Features.History.Clients;
using Education.Client.Features.History.Clients.DateGuesser;
using Education.Client.Features.History.Clients.DateGuesser.Model;
using Education.Client.Features.History.Clients.DateGuesser.Request;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace Education.Client.Features.History.Pages.DateGuessers;

public sealed partial class DateGuesserMainPage : ComponentBase
{
    private readonly List<BreadcrumbItem> _breadcrumbs;
    private readonly IHistoryDateGuesserClient _dateGuesserClient;
    private readonly IStringLocalizer<App> _localizer;
    private readonly NavigationManager _navigation;
    private readonly ISnackbar _snackbar;
    private readonly ILocalStorageService _storage;
    private ApiResult<DateGuesserBuilderModel> _response = ApiResult<DateGuesserBuilderModel>.Loading();
    private Settings _settings = new(EpochType.None);

    public DateGuesserMainPage(IStringLocalizer<App> localizer, IHistoryDateGuesserClient dateGuesserClient,
        ISnackbar snackbar, NavigationManager navigation, ILocalStorageService storage)
    {
        _localizer = localizer;
        _dateGuesserClient = dateGuesserClient;
        _snackbar = snackbar;
        _navigation = navigation;
        _storage = storage;
        _breadcrumbs =
        [
            new BreadcrumbItem(_localizer["History_Title"], HistoryUrl.Root),
            new BreadcrumbItem(_localizer["History_DateGuessers_Title"], null, true)
        ];
    }

    protected override async Task OnInitializedAsync()
    {
        _settings = await _storage.GetItemAsync<Settings>(HistoryLocalStorageKey.DateGuesserSettings) ?? _settings;
        _response = await _dateGuesserClient.GetAsync();
        _response.MatchError(x =>
        {
            if (x.IsDateGuesserAlreadyCreated(out var id))
                _navigation.NavigateTo(HistoryUrl.DateGuesser.Test(id));
        });
    }

    private async Task CreateTestAsync(DateGuesserSize size)
    {
        var result = await _dateGuesserClient.CreateAsync(new CreateRequest(size, _settings.Epoch));
        result.Match(
            x => _navigation.NavigateTo(HistoryUrl.DateGuesser.Test(x.Id)),
            e => _snackbar.Add(e.UiMessage, Severity.Error)
        );
    }

    private async Task ChangeEpochAsync(EpochType epoch)
    {
        _settings = new Settings(epoch);

        await _storage.SetItemAsync(HistoryLocalStorageKey.DateGuesserSettings, _settings);
    }

    private sealed record Settings(EpochType Epoch);
}
