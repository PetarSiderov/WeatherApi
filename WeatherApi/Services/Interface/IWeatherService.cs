using WeatherApi.Models.WeatherAPI;

namespace WeatherApi.Services.Interface
{
    public interface IWeatherService
    {  
        Task<CurrentWeather> getCurrentWeather(double lat, double lng);
    }
}
