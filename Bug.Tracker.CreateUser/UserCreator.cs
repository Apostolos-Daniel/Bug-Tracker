using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Bug.Tracker.Models;
using Newtonsoft.Json;

namespace Bug.Tracker.CreateUser
{
    public class UserCreator : IUserCreator
    {
        private readonly HttpClient _httpClient;

        public UserCreator(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("bugTrackerClient");
        }

        public async Task<User> CreateUser(string name)
        {
            var user = await _httpClient.PostAsync($"{_httpClient.BaseAddress}users/name/{name}", null);
            return JsonConvert.DeserializeObject<User>(await user.Content.ReadAsStringAsync());
        }
    }
}
