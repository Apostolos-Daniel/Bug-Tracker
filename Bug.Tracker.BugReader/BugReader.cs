using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Bug.Tracker.Models;
using Bug.Tracker.Models.Enums;
using Newtonsoft.Json;

namespace Bug.Tracker.BugReader
{
    public class BugReader : IBugReader
    {
        private readonly HttpClient _httpClient;

        public BugReader(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("bugTrackerClient");
        }

        public async Task<IEnumerable<BugItem>> GetBugItems(BugStatus status)
        {
            var bugItems = await _httpClient.GetAsync($"bugs");
            return JsonConvert.DeserializeObject<IEnumerable<BugItem>>(await bugItems.Content.ReadAsStringAsync());
        }
    }
}
