using Bug.Tracker.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bug.Tracker.BugCreator
{
    public class BugCreator : IBugCreator
    {
        private readonly HttpClient _httpClient;

        public BugCreator(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("bugTrackerClient");
        }

        public async Task<BugItem> CreateBug(string title, string description)
        {
            // create new bug
            var bugItemCreated = await _httpClient.PostAsync($"https://localhost:44342/api/bugs/title/{title}/description/{description}", null);

            return JsonConvert.DeserializeObject<BugItem>(await bugItemCreated.Content.ReadAsStringAsync());
        }
    }
}
