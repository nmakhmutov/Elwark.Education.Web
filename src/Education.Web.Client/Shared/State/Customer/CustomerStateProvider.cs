using Education.Web.Client.Extensions;
using Education.Web.Client.Features.Customer.Services.Account;
using Education.Web.Client.Features.Customer.Services.Account.Model;
using Microsoft.AspNetCore.Components.Authorization;

namespace Education.Web.Client.Shared.State.Customer;

internal sealed class CustomerStateProvider
{
    private readonly AuthenticationStateProvider _provider;
    private readonly ICustomerService _service;
    private bool _isInitialized;
    private CustomerState _state;

    public CustomerStateProvider(ICustomerService service, AuthenticationStateProvider provider)
    {
        _service = service;
        _provider = provider;
        _state = CustomerState.Anonymous;
    }

    public event Action<CustomerState> OnChanged = _ => { };

    public async ValueTask InitAsync()
    {
        if (_isInitialized)
            return;

        var state = await _provider.GetAuthenticationStateAsync();
        if (state.User.Identity?.IsAuthenticated == false)
            return;

        var customer = await GetOrCreateCustomerAsync();
        if (customer is null)
            return;

        _state = CustomerState.Authenticated(
            customer.FullName,
            customer.Image,
            customer.TimeZone,
            customer.StartOfWeek,
            customer.DateFormat,
            customer.TimeFormat,
            customer.CreatedAt
        );

        _isInitialized = true;
        OnChanged.Invoke(_state);
    }

    public CustomerState GetCurrentState() =>
        _state;

    private async Task<CustomerModel?> GetOrCreateCustomerAsync()
    {
        var customer = await _service.GetAsync();
        if (customer.IsSuccess)
            return customer.Value;

        if (!customer.Error.IsUserNotFound())
            return null;

        var result = await _service.CreateAsync();
        return result.IsSuccess ? result.Value : null;
    }
}
