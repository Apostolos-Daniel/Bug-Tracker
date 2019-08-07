using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Bug.Tracker.BugReader;
using Bug.Tracker.Models;
using Bug.Tracker.Models.Enums;
using Newtonsoft.Json;

namespace Bug.Tracker.BugUpdater
{
    public class BugUpdater : IBugUpdater
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        internal IBugReader BugReader { get; }

        public BugUpdater(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("bugTrackerClient");
            BugReader = new BugReader.BugReader(_httpClientFactory);
        }

        public async Task<BugItem> UpdateStatus(Guid bugItemId, BugStatus status, string userId = null)
        {
            var bugItemToUpdate = (await BugReader.GetBugItems(BugStatus.open)).FirstOrDefault(x => x.Id == bugItemId);
            if (bugItemToUpdate == null)
            {
                bugItemToUpdate = (await BugReader.GetBugItems(BugStatus.closed)).FirstOrDefault(x => x.Id == bugItemId);
                if (bugItemToUpdate == null)
                {
                    throw new Exception($"No bug with given bug id {bugItemId} was found");
                }
            }
            bugItemToUpdate.Status = status;
            HttpResponseMessage bugItems;
            if (!string.IsNullOrEmpty(userId))
            {
               bugItems  = await _httpClient.PutAsync($"{_httpClient.BaseAddress}bugs/id/{bugItemToUpdate.Id}/status/{status.ToString()}/user-id/{userId}", null);
                return JsonConvert.DeserializeObject<BugItem>(await bugItems.Content.ReadAsStringAsync());
            }
            bugItems = await _httpClient.PutAsync($"{_httpClient.BaseAddress}bugs/id/{bugItemToUpdate.Id}/status/{status.ToString()}", null);
            return JsonConvert.DeserializeObject<BugItem>(await bugItems.Content.ReadAsStringAsync());
        }
    }
}
