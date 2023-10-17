using WeatherApi.Entities;
using WeatherApi.Repositories.Interfaces;

namespace WeatherApi.Repositories
{
    public class WorldCityRepostitory : IWorldCityRepository
    {
        private WeatherContextt weatherContextt;
        public WorldCityRepostitory(WeatherContextt weatherContextt)
        {
            this.weatherContextt = weatherContextt;
        }
        public async Task<WorldCity> getCityLangLong(string cityName)
        {
            return  weatherContextt.WorldCities.Where(s => s.CityAscii.ToLower().Equals(cityName.ToLower())).FirstOrDefault();
        }
    }
}
