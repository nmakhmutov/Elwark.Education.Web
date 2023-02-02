using Education.Web.Client.Features.Customer.Services.Account.Model;
using Education.Web.Client.Http;

namespace Education.Web.Client.Features.Customer.Services.Account;

internal interface ICustomerService
{
    Task<ApiResult<CustomerModel>> GetAsync();

    Task<ApiResult<CustomerModel>> CreateAsync();

    Task<ApiResult<SubjectModel[]>> GetSubjectsAsync();
}
