using Education.Client.Extensions;
using Education.Client.Features.Customer.Services;
using Education.Client.Features.Customer.Services.Account;
using Education.Client.Features.Customer.Services.Account.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace Education.Client.Shared.Customer;

internal sealed class CustomerStateProvider : IDisposable
{
    private readonly IAccountClient _accountClient;
    private readonly CustomerHab _hab;
    private readonly AuthenticationStateProvider _provider;
    private readonly HashSet<StateChangedSubscription> _subscriptions = [];
    private bool _isInitialized;
    private CustomerState _state;
    private IDisposable? _subscription;

    public CustomerStateProvider(CustomerHab hab, IAccountClient accountClient,
        AuthenticationStateProvider provider)
    {
        _accountClient = accountClient;
        _provider = provider;
        _hab = hab;
        _state = CustomerState.Anonymous;
    }

    public void Dispose()
    {
        _subscriptions.Clear();
        _subscription?.Dispose();
    }

    public IDisposable NotifyOnChange(EventCallback<CustomerState> callback)
    {
        var subscription = new StateChangedSubscription(this, callback);
        _subscriptions.Add(subscription);

        return subscription;
    }

    public async Task InitAsync()
    {
        if (_isInitialized)
        {
            await NotifyChangeSubscribersAsync(_state);
            return;
        }

        var state = await _provider.GetAuthenticationStateAsync();
        if (state.User.Identity?.IsAuthenticated == false)
            return;

        var callback = EventCallback.Factory.Create<CustomerChangedType>(this, OnCustomerChanged);
        _subscription = _hab.NotifyOnCustomerChange(callback);

        await UpdateCustomer();

        _isInitialized = true;
    }

    private Task OnCustomerChanged(CustomerChangedType status)
    {
        if (status == CustomerChangedType.Updated)
            return UpdateCustomer();

        return Task.CompletedTask;
    }

    private async Task UpdateCustomer()
    {
        var customer = await GetOrCreateCustomerAsync();
        if (customer is null)
            return;

        _state = CustomerState.Map(customer);
        await NotifyChangeSubscribersAsync(_state);
    }

    private async Task<CustomerModel?> GetOrCreateCustomerAsync()
    {
        var customer = await _accountClient.GetAsync();
        if (customer.IsSuccess)
            return customer.Unwrap();

        if (!customer.UnwrapError().IsUserNotFound())
            return null;

        var result = await _accountClient.CreateAsync();
        return result.IsSuccess ? result.Unwrap() : null;
    }

    private Task NotifyChangeSubscribersAsync(CustomerState state) =>
        Task.WhenAll(_subscriptions.Select(s => s.NotifyAsync(state)));

    private sealed class StateChangedSubscription : IDisposable
    {
        private readonly EventCallback<CustomerState> _callback;
        private readonly CustomerStateProvider _owner;

        public StateChangedSubscription(CustomerStateProvider owner, EventCallback<CustomerState> callback)
        {
            _owner = owner;
            _callback = callback;
        }

        public void Dispose() =>
            _owner._subscriptions.Remove(this);

        public Task NotifyAsync(CustomerState state) =>
            _callback.InvokeAsync(state);
    }
}
