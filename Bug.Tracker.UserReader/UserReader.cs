using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Bug.Tracker.Models;
using Newtonsoft.Json;

namespace Bug.Tracker.UserReader
{
    public class UserReader : IUserReader
    {
        private readonly HttpClient _httpClient;

        public UserReader(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("bugTrackerClient");
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _httpClient.GetAsync($"{_httpClient.BaseAddress}users");
            var usersDes = JsonConvert.DeserializeObject<IEnumerable<User>>(await users.Content.ReadAsStringAsync());

            var user = usersDes.FirstOrDefault(x => x.Name == "Adam Lynas");
            return usersDes;
        }
    }
}
