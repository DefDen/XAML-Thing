using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IndependentProject.Models;
using Newtonsoft.Json;

namespace IndependentProject
{
    class Retriever
    {
        private string musixMatchKey = "2eb5dcbf3889a59f9a6ff077176d906a";

        public async Task<MusicSearchRootObject> GetTrackSearchResults(string track)
        {  
            HttpClient httpClient = new HttpClient();
            String apiUrl = $"http://api.musixmatch.com/ws/1.1/track.search?q_track={track}&apikey={musixMatchKey}";

            string responeString = await httpClient.GetStringAsync(apiUrl);

            MusicSearchRootObject results = JsonConvert.DeserializeObject<MusicSearchRootObject>(responeString);

            return results;
        }
    }
}
