using Education.Http;
using Education.Web.Client.Services.Customer.Account.Model;

namespace Education.Web.Client.Services.Customer.Account;

internal interface ICustomerService
{
    Task<ApiResult<CustomerModel>> GetAsync();

    Task<ApiResult<CustomerModel>> CreateAsync();

    Task<ApiResult<SubjectModel[]>> GetSubjectsAsync();
}
