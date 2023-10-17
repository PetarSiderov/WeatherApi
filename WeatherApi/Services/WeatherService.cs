using System.Text.Json;
using System.Text.Json.Serialization;
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
        public async Task<CurrentWeather> getCurrentWeather(double lat, double lng)
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

                        return jsonSerializer.current;
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
            throw new NotImplementedException();
        }
    }
}
