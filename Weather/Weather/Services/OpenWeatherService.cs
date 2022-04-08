using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json; //Requires nuget package System.Net.Http.Json
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Text.Json;

using Weather.Models;

namespace Weather.Services
{
    //You replace this class witth your own Service from Project Part A
    public class OpenWeatherService
    {
        HttpClient httpClient = new HttpClient();
        readonly string apiKey = "03ca866006a2319edcd9062173e64a7c"; // Your API Key

        // part of your event and cache code here
        public event EventHandler<string> WeatherForecastAvailable;
        ConcurrentDictionary<(string, string), Forecast> _cacheDictionaryCity = new ConcurrentDictionary<(string, string), Forecast>();
        ConcurrentDictionary<(double, double, string), Forecast> _cacheDictionaryGeo = new ConcurrentDictionary<(double, double, string), Forecast>();

        public async Task<Forecast> GetForecastAsync(string City)
        {
            //part of cache code here
            //https://openweathermap.org/current
            var language = System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            var uri = $"https://api.openweathermap.org/data/2.5/forecast?q={City}&units=metric&lang={language}&appid={apiKey}";

            string keyDate = DateTime.Now.ToString("yyyy-MM-dd:HH:mm");
            string keyCity = City;
            var key = (keyCity, keyDate);

            if (!_cacheDictionaryCity.TryGetValue(key, out var forecast))
            {
                forecast = new Forecast();
                forecast = await ReadWebApiAsync(uri);
                _cacheDictionaryCity[key] = forecast;
            }

            return forecast;
        }
        public async Task<Forecast> GetForecastAsync(double latitude, double longitude)
        {
            //https://openweathermap.org/current
            var language = System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            var uri = $"https://api.openweathermap.org/data/2.5/forecast?lat={latitude}&lon={longitude}&units=metric&lang={language}&appid={apiKey}";

            double keyLat = latitude;
            double keyLong = longitude;
            string keyDate = DateTime.Now.ToString("yyyy-MM-dd:HH:mm");
            var key = (keyLat, keyLong, keyDate);

            if (!_cacheDictionaryGeo.TryGetValue(key, out var forecast))
            {
                forecast = new Forecast();
                forecast = await ReadWebApiAsync(uri);
                _cacheDictionaryGeo[key] = forecast;
            }

            return forecast;
        }
        private async Task<Forecast> ReadWebApiAsync(string uri)
        {
            // part of your read web api code here
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            WeatherApiData wd = await response.Content.ReadFromJsonAsync<WeatherApiData>();

            // part of your data transformation to Forecast here
            Forecast forecast = new Forecast()
            {
                City = wd.city.name,
            };

            forecast.Items = wd.list.Select(x => new ForecastItem
            {
                WindSpeed = x.wind.speed,
                Temperature = x.main.temp,
                DateTime = UnixTimeStampToDateTime(x.dt),
                Icon = x.weather[0].icon,
                Description = x.weather[0].description
            }).ToList();


            return forecast;
        }
        private DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
    }
}
