using System.Threading.Tasks;
using Elwark.Education.Web.Services.User.Model;

namespace Elwark.Education.Web.Services.User
{
    public interface IUserService
    {
        Task<SubscriptionItem[]> GetSubscriptionsAsync();

        Task CreateAsync();
        
        Task<UserStatistics> GetTotalProgressAsync();
        
        Task<Profile> GetProfileAsync();
    }
}