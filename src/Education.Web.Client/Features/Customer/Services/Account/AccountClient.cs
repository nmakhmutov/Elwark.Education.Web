using Education.Web.Client.Clients;
using Education.Web.Client.Features.Customer.Services.Account.Model;

namespace Education.Web.Client.Features.Customer.Services.Account;

internal sealed class AccountClient : IAccountClient
{
    private readonly CustomerApiClient _api;

    public AccountClient(CustomerApiClient api) =>
        _api = api;

    public Task<ApiResult<CustomerModel>> GetAsync() =>
        _api.GetAsync<CustomerModel>("customers/me");

    public Task<ApiResult<CustomerModel>> CreateAsync() =>
        _api.PostAsync<CustomerModel>("customers/me");

    public Task<ApiResult<SubjectModel[]>> GetSubjectsAsync() =>
        _api.GetAsync<SubjectModel[]>("customers/me/subjects");
}
