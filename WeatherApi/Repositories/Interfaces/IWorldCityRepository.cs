using WeatherApi.Entities;

namespace WeatherApi.Repositories.Interfaces
{
    public interface IWorldCityRepository
    {
        Task<WorldCity> getCityLangLong(string cityName);
    }
}
