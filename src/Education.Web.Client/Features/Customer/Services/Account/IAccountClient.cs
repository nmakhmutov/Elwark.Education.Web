using Education.Web.Client.Clients;
using Education.Web.Client.Features.Customer.Services.Account.Model;

namespace Education.Web.Client.Features.Customer.Services.Account;

internal interface IAccountClient
{
    Task<ApiResult<CustomerModel>> GetAsync();

    Task<ApiResult<CustomerModel>> CreateAsync();

    Task<ApiResult<SubjectModel[]>> GetSubjectsAsync();
}
