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
        
        //API calls for music searches using song names and artists. Also determines wheather a normal or advanced search is being performed and respones accordingly
        public async Task<MusicSearchRootObject> GetTrackSearchResults(string term, string term2, bool isAdvancedSearch, bool isTrackSearch)
        {
            HttpClient httpClient = new HttpClient();
            String apiUrl = "";

            if (isAdvancedSearch)
            {
                apiUrl = $"http://api.musixmatch.com/ws/1.1/track.search?q_track={term}&q_artist={term2}&s_track_rating&s_artist_rating&page_size=100&f_has_lyrics&f_lyrics_language=en&apikey={musixMatchKey}";
            }
            else
            { 
                if (isTrackSearch)
                {
                    apiUrl = $"http://api.musixmatch.com/ws/1.1/track.search?q_track={term}&s_track_rating&s_artist_rating&page_size=100&f_has_lyrics&f_lyrics_language=en&apikey={musixMatchKey}";
                }
                else
                {
                    apiUrl = $"http://api.musixmatch.com/ws/1.1/track.search?q_artist={term}&s_track_rating&s_artist_rating&page_size=100&f_has_lyrics&f_lyrics_language=en&apikey={musixMatchKey}";
                }
            }
            string responeString = await httpClient.GetStringAsync(apiUrl);

            MusicSearchRootObject results = JsonConvert.DeserializeObject<MusicSearchRootObject>(responeString);

            return results;
        }
        
        //API call for getting the lyrics for a particular song after getting its track id
        public async Task<LyricsRootObject> GetLyrics(string trackId)
        {
            HttpClient httpClient = new HttpClient();
            String apiUrl = $"http://api.musixmatch.com/ws/1.1/track.lyrics.get?track_id={trackId}&apikey={musixMatchKey}";

            string responseString = await httpClient.GetStringAsync(apiUrl);

            LyricsRootObject results = JsonConvert.DeserializeObject<LyricsRootObject>(responseString);

            return results;
        }

        //API call for getting the information on a song such as ablum name using a track id
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
