using System.Text.Json;
using System.Text.Json.Serialization;
using WeatherApi.Entities;
using WeatherApi.Models.WeatherAPI;
using WeatherApi.Services.Interface;

namespace WeatherApi.Services
{
    public class WeatherService : IWeatherService
    {
        private string API_KEY = "1bb4d119e33fe179da8234bf8cec0728";
        public WeatherService()
        {

        }

        public async Task<CurrentWeatherViewModel?> getCurrentWeather(WorldCity worldCity)
        {
            try
            {
                var openWeatherMapResponse = await getCurrentWeatherAPI((double)worldCity.Lat, (double)worldCity.Lng);

                CurrentWeatherViewModel currentWeather = new CurrentWeatherViewModel()
                {
                    cityName = worldCity.CityAscii + ", " + worldCity.Country + ", " + worldCity.Iso2,
                    dailyPrediction = openWeatherMapResponse
                };

                return currentWeather;
            }
            catch(Exception ex) {
                return null;
            }
        }

        private async Task<List<Daily>?> getCurrentWeatherAPI(double lat, double lng)
        {
            try
            {
                using(HttpClient client = new HttpClient()) {

                    string apiUrl = $"https://api.openweathermap.org/data/3.0/onecall?lat={lat}&lon={lng}&exclude=hourly,minutely&appid={API_KEY}";

                    var response = await client.GetAsync(apiUrl).Result.Content.ReadAsStringAsync();

                    if (response != null)
                    {
                        // Read and parse the response content
                       var jsonSerializer = JsonSerializer.Deserialize<WeatherData>(response);

                        return jsonSerializer?.daily;
                    }
                    else
                    {
                        return null;
                    }

                }

            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
