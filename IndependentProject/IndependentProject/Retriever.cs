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

        public async Task<MusicSearchRootObject> GetTrackSearchResults(string term, bool isTrackSearch)
        {  
            HttpClient httpClient = new HttpClient();
            String apiUrl = "";

            if(isTrackSearch)
            {
                apiUrl = $"http://api.musixmatch.com/ws/1.1/track.search?q_track={term}&s_track_rating&s_artist_rating&page_size=100&f_has_lyrics&apikey={musixMatchKey}";
            }
            else
            {
                apiUrl = $"http://api.musixmatch.com/ws/1.1/track.search?q_artist={term}&s_track_rating&s_artist_rating&page_size=100&f_has_lyrics&apikey={musixMatchKey}";
            }

            string responeString = await httpClient.GetStringAsync(apiUrl);

            MusicSearchRootObject results = JsonConvert.DeserializeObject<MusicSearchRootObject>(responeString);

            return results;
        }
        
        public async Task<LyricsRootObject> GetLyrics(string trackId)
        {
            HttpClient httpClient = new HttpClient();
            String apiUrl = $"https://api.musixmatch.com/ws/1.1/track.lyrics.get?track_id={trackId}&apikey={musixMatchKey}";

            string responseString = await httpClient.GetStringAsync(apiUrl);

            LyricsRootObject results = JsonConvert.DeserializeObject<LyricsRootObject>(responseString);

            return results;
        }

        public async Task<MusicFromIdRootObject> GetMusic(string trackId)
        {
            HttpClient httpClient = new HttpClient();
            String apiUrl = $"https://api.musixmatch.com/ws/1.1/track.get?commontrack_id={trackId}&apikey={musixMatchKey}";

            string responseString = await httpClient.GetStringAsync(apiUrl);

            MusicFromIdRootObject results = JsonConvert.DeserializeObject<MusicFromIdRootObject>(responseString);

            return results;
        }
    }
}
