using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;

namespace WeatherApp.ViewModel.Helpers
{
    public class WeatherHelper
    {
        private const string m_BaseURL = "http://dataservice.accuweather.com/";
        
        private const string m_AutocompleteEndpoint = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
        private const string m_ConditionsEndpoint   = "currentconditions/v1/{0}?apikey={1}";

       
        // ----------------------------------------------------------------
        // This is where you will insert your own API key from AccuWeather
        // ----------------------------------------------------------------
        private const string m_ApiKey = "YOUR API KEY HERE";
        // ----------------------------------------------------------------
        // ----------------------------------------------------------------
        

        // ----------------------------------------------------------------
        // ----------------------------------------------------------------
        public static async Task<List<City>> GetCities(string query)
        {
            List<City> cities = new List<City>();
            string formattedURL = m_BaseURL + string.Format(m_AutocompleteEndpoint, m_ApiKey, query);

            using(HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(formattedURL);
                string json = await response.Content.ReadAsStringAsync();

                cities = JsonConvert.DeserializeObject<List<City>>(json);
            }

            return cities;
        }


        // ----------------------------------------------------------------
        // ----------------------------------------------------------------
        public static async Task<CurrentConditions> GetCurrentConditions(string cityKey)
        {
            CurrentConditions currentConditions = new CurrentConditions();
            string formattedURL = m_BaseURL + string.Format(m_ConditionsEndpoint, cityKey, m_ApiKey);

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(formattedURL);
                string json = await response.Content.ReadAsStringAsync();

                currentConditions = (JsonConvert.DeserializeObject<List<CurrentConditions>>(json)).FirstOrDefault();
            }

            return currentConditions;
        }

    }
}
