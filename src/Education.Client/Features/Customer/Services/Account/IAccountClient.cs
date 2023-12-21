using Education.Client.Clients;
using Education.Client.Features.Customer.Services.Account.Model;

namespace Education.Client.Features.Customer.Services.Account;

internal interface IAccountClient
{
    Task<ApiResult<CustomerModel>> GetAsync();

    Task<ApiResult<CustomerModel>> CreateAsync();

    Task<ApiResult<SubjectModel[]>> GetSubjectsAsync();
}
