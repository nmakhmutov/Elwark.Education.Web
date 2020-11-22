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

        public async Task<UserModel?> GetAsync()
        {
            var response = await _client.GetAsync("users");
            
            return response.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<UserModel>(await response.Content.ReadAsStringAsync())
                : null;
        }

        public async Task<UserModel> CreateAsync()
        {
            var response = await _client.PostAsync("users", new StringContent(string.Empty, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<UserModel>(await response.Content.ReadAsStringAsync());
            
            throw new Exception("User not created");
        }
    }
}