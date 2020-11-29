using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Elwark.Education.Web.Services.User.Model;
using Newtonsoft.Json;

namespace Elwark.Education.Web.Services.User
{
    public class UserService : IUserService
    {
        private readonly HttpClient _client;

        public UserService(HttpClient client) =>
            _client = client;

        public async Task<SubscriptionItem[]> GetSubscriptionsAsync()
        {
            var response = await _client.GetAsync("users/me/subscriptions");
            
            return response.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<SubscriptionItem[]>(await response.Content.ReadAsStringAsync())
                : Array.Empty<SubscriptionItem>();
        }

        public async Task<TotalProgress> GetTotalProgressAsync()
        {
            var response = await _client.GetAsync("users/me/progress");
            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<TotalProgress>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Profile> GetProfileAsync()
        {
            var response = await _client.GetAsync("users/me");
            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<Profile>(await response.Content.ReadAsStringAsync());
        }

        public async Task CreateAsync()
        {
            var response = await _client.PostAsync("users", new StringContent(string.Empty, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }
    }
}