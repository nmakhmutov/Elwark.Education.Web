using Education.Web.Client.Services.Api;
using Education.Web.Client.Services.Customer;
using Education.Web.Client.Services.Customer.Model;
using Microsoft.AspNetCore.Components.Authorization;

namespace Education.Web.Client.Components.Customer;

internal sealed class CustomerStateProvider
{
    private readonly ICustomerService _service;
    private readonly AuthenticationStateProvider _stateProvider;
    private bool _isInitialized;
    private CustomerState _state;

    public CustomerStateProvider(ICustomerService service, AuthenticationStateProvider stateProvider)
    {
        _service = service;
        _stateProvider = stateProvider;
        _state = CustomerState.Anonymous;
    }

    public event Action<CustomerState> OnChanged = _ => { };

    public async ValueTask InitAsync()
    {
        if (_isInitialized)
            return;

        var state = await _stateProvider.GetAuthenticationStateAsync();
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
            return customer.Data;

        if (!customer.Error.IsUserNotFound())
            return null;

        var result = await _service.CreateAsync();
        return result.IsSuccess ? result.Data : null;
    }
}
