using Education.Client.Clients;
using Education.Client.Features.Customer.Services.Notification;
using Education.Client.Features.Customer.Services.Notification.Model;
using Education.Client.Features.Customer.Services.Notification.Request;
using Education.Client.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Education.Client.Features.Customer.Pages.Notifications;

public sealed partial class Page : ComponentBase
{
    private readonly IStringLocalizer<App> _localizer;
    private readonly List<NotificationModel> _notifications = [];
    private readonly INotificationService _notificationService;
    private bool _isMoreLoading;
    private NotificationsRequest _request = new(10);

    private ApiResult<PagingTokenModel<NotificationModel>> _response =
        ApiResult<PagingTokenModel<NotificationModel>>.Loading();

    public Page(IStringLocalizer<App> localizer, INotificationService notificationService)
    {
        _localizer = localizer;
        _notificationService = notificationService;
    }

    protected override async Task OnInitializedAsync()
    {
        _response = await _notificationService.GetAsync(_request);
        _response.Match(x =>
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
        var result = await _notificationService.GetAsync(_request);
        result.Match(
            x =>
            {
                _request = _request with
                {
                    Token = x.Next
                };
                _notifications.AddRange(x.Items);
            },
            e => _response = ApiResult<PagingTokenModel<NotificationModel>>.Fail(e)
        );
        _isMoreLoading = false;
    }

    private async Task MarkAsReadAsync(string id)
    {
        await _notificationService.MarkAsReadAsync(id);
        _notifications.RemoveAll(x => x.Id == id);
    }

    private async Task MarkAllAsReadAsync()
    {
        await _notificationService.MarkAllAsReadAsync();
        _request = _request with
        {
            Token = null
        };
        _notifications.Clear();
    }
}
