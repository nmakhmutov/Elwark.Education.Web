using Education.Web.Client.Extensions;
using Education.Web.Client.Features.Customer.Services.Account;
using Education.Web.Client.Features.Customer.Services.Account.Model;
using Microsoft.AspNetCore.Components.Authorization;

namespace Education.Web.Client.Shared.Customer;

internal sealed class CustomerStateProvider
{
    private readonly AuthenticationStateProvider _provider;
    private readonly ICustomerService _customerService;
    private bool _isInitialized;
    private CustomerState _state;

    public CustomerStateProvider(ICustomerService customerService, AuthenticationStateProvider provider)
    {
        _customerService = customerService;
        _provider = provider;
        _state = CustomerState.Anonymous;
    }

    public event Action<CustomerState> OnChanged = _ =>
    {
    };

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

        _state = CustomerState.Map(customer);
        _isInitialized = true;

        OnChanged.Invoke(_state);
    }

    public CustomerState GetCurrentState() =>
        _state;

    private async Task<CustomerModel?> GetOrCreateCustomerAsync()
    {
        var customer = await _customerService.GetAsync();
        if (customer.IsSuccess)
            return customer.Unwrap();

        if (!customer.UnwrapError().IsUserNotFound())
            return null;

        var result = await _customerService.CreateAsync();
        return result.IsSuccess ? result.Unwrap() : null;
    }
}
