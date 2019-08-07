using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Bug.Tracker.Models;
using Bug.Tracker.UserReader;
using Newtonsoft.Json;

namespace Bug.Tracker.UserUpdater
{
    public class UserUpdater : IUserUpdater
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;

        internal IUserReader UserReader { get; }

        public UserUpdater(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = httpClientFactory.CreateClient("bugTrackerClient");
            UserReader = new UserReader.UserReader(_httpClientFactory);
        }

        public async Task<User> UpdateUserName(Guid userId, string name)
        {
            var userToUpdate = (await UserReader.GetUsers()).FirstOrDefault(x => x.Id == userId);
            if (userToUpdate == null)
            {
                throw new Exception($"No user with given user id {userId} was found");
            }
            userToUpdate.Name = name;

            var users = await _httpClient.PutAsync($"{_httpClient.BaseAddress}users/id/{userToUpdate.Id}/name/{name}", null);
            return JsonConvert.DeserializeObject<User>(await users.Content.ReadAsStringAsync());
        }
    }
}
