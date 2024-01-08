using Education.Client.Clients;
using Education.Client.Features.Customer.Services.Notification;
using Education.Client.Features.Customer.Services.Notification.Model;
using Education.Client.Features.Customer.Services.Notification.Request;
using Education.Client.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Client.Features.Customer.Pages.Notifications;

public sealed partial class Page
{
    private readonly List<NotificationModel> _notifications = [];
    private bool _isMoreLoading;
    private NotificationsRequest _request = new(10);

    private ApiResult<PagingTokenModel<NotificationModel>> _result =
        ApiResult<PagingTokenModel<NotificationModel>>.Loading();

    [Inject]
    private IStringLocalizer<App> L { get; init; } = default!;

    [Inject]
    private INotificationService NotificationService { get; init; } = default!;

    protected override async Task OnInitializedAsync()
    {
        _result = await NotificationService.GetAsync(_request);
        _result.Match(x =>
        {
            _notifications.AddRange(x.Items);
            _request = new NotificationsRequest(20, x.Next);
        });
    }

    private async Task LoadMoreAsync()
    {
        if (_request.Token is null)
            return;

        _isMoreLoading = true;
        var result = await NotificationService.GetAsync(_request);
        result.Match(
            x =>
            {
                _request = _request with { Token = x.Next };
                _notifications.AddRange(x.Items);
            },
            e => _result = ApiResult<PagingTokenModel<NotificationModel>>.Fail(e)
        );
        _isMoreLoading = false;
    }

    private async Task MarkAsReadAsync(string id)
    {
        await NotificationService.MarkAsReadAsync(id);
        _notifications.RemoveAll(x => x.Id == id);
    }

    private async Task MarkAllAsReadAsync()
    {
        await NotificationService.MarkAllAsReadAsync();
        _request = _request with { Token = null };
        _notifications.Clear();
    }
}
