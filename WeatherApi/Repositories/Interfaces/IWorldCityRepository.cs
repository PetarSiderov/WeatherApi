using WeatherApi.Entities;
using WeatherApi.Models;

namespace WeatherApi.Repositories.Interfaces
{
    public interface IWorldCityRepository
    {
        Task<WorldCity> getCityLangLong(string cityName);
        Task<List<CitySimplier>> getAllCities();
    }
}
