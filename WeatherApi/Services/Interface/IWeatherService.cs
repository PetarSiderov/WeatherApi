using WeatherApi.Entities;
using WeatherApi.Models.WeatherAPI;

namespace WeatherApi.Services.Interface
{
    public interface IWeatherService
    {
        Task<CurrentWeatherViewModel> getCurrentWeather(WorldCity worldCity);
    }
}
