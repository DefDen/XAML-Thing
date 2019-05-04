using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Lab6.Models;
using Newtonsoft.Json;
using Lab6.Models.Forecast;
using Lab6.Models.Auto;
using System.Collections.ObjectModel;
using Lab6.ViewModels;

namespace Lab6
{
    class WeatherRetriever
    {
        private string apiKey = "l8xTI0mjcGrVqeDOcmlgo";
        private string secret = "SNtPEIaXgTpG3o2faDreuLjhDY9CTvcEYWY3H11M";

        public async Task<ObservationsRootObject> GetObservations(string cityLink)
        {
            HttpClient httpClient = new HttpClient();
            String apiUrl = $"https://api.aerisapi.com/observations/{cityLink}?client_id={apiKey}&client_secret={secret}";

            string responseString = await httpClient.GetStringAsync(apiUrl);

            ObservationsRootObject observations = JsonConvert.DeserializeObject<ObservationsRootObject>(responseString);

            return observations;
        }

        public async Task<AutoCompleteRootObject> GetSuggestions(string enteredStr)
        {
            HttpClient httpClient = new HttpClient();
            string apiUrl = $"http://api.aerisapi.com/places/search?query=name:^{enteredStr}&limit=10&client_id={apiKey}&client_secret={secret}";

            string responseString = await httpClient.GetStringAsync(apiUrl);

            AutoCompleteRootObject suggestions = JsonConvert.DeserializeObject<AutoCompleteRootObject>(responseString);

            return suggestions;
        }

        public async Task<ForecastRootObject> GetForecasts(string enteredStr)
        {
            HttpClient httpClient = new HttpClient();
            string apiUrl = $"https://api.aerisapi.com/forecasts/{enteredStr}?limit=4&filter=day&client_id={apiKey}&client_secret={secret}";

            string responseString = await httpClient.GetStringAsync(apiUrl);

            ForecastRootObject r = JsonConvert.DeserializeObject<ForecastRootObject>(responseString);

            return r;
        }
    }
}
